using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Reflection;
using System.Windows.Threading;
using System.Text.RegularExpressions;

// Json Lib
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// WebSocket Libs
using WebSocketSharp.Server;
// FSUIPC
using FSUIPC;

namespace FSXWebService
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data

        DispatcherTimer timerMain, timerConnection;
        Dictionary<String, Object> previousValues, deltaValues;

        // 连接 FSUIPC 
        WebSocketServer wssv = new WebSocketServer(8080);

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // 初始化
            timerMain = new DispatcherTimer();
            timerConnection = new DispatcherTimer();
            deltaValues = new Dictionary<string, Object>();
            previousValues = new Dictionary<string, Object>();

            // 配置初始化
            GetConfiguration();

            // 创建 WebServer 服务器
            //String ss = Config["webserver"]["port"].ToString();
            LocalWebServer localWS = new LocalWebServer((int) Config["webserver"]["port"],
                Config["webserver"]["servingFromDirectory"].ToString());
            localWS.StartWebService();

            // 开始 WebSocket 服务
            WSSStart("");

            ConfigureForm();

            //////////////////////////////////////////////////////////////////////////
            var result = new NCalc.Expression("5 + 3.2");
            var tmp = result.Evaluate();
            decimal x = Convert.ToDecimal(tmp);
            //////////////////////////////////////////////////////////////////////////
            ///
            timerMain.Interval = TimeSpan.FromMilliseconds(25);
            timerMain.Tick += TimerMain_Tick;
            timerConnection.Interval = TimeSpan.FromMilliseconds(1000);
            timerConnection.Tick += TimerConnection_Tick;

            timerConnection.Start();
        }

        #region Property

        public JObject Config
        {
            get;
            set;
        }

        #endregion

        #region Method

        public void GetConfiguration()
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText("config.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    Config = JObject.Load(reader);
                }
            };
        }

        void WSSStart(String servicename)
        {
            wssv.AddWebSocketService<WSFSUIPC>("/fsuipc");
            wssv.Start();
        }

        void ConfigureForm()
        {
            if(FSUIPC.FSUIPCConnection.IsOpen)
            {
                lblConnectionStatus.Text = "Connected to " +
                    FSUIPC.FSUIPCConnection.FlightSimVersionConnected.ToString();
                lblConnectionStatus.Foreground = Brushes.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Disconnected. Looking for FSX...";
                lblConnectionStatus.Foreground = Brushes.Red;
            }

            lblWebsocketConfig.Text = "Gauges from " + Config["webserver"]["servingFromDirectory"].ToString();
            btnOpenUrl.Content = "Open Gauges from : " +
                    System.Environment.MachineName.ToString() + ":" +
                    Config["webserver"]["port"].ToString();
        }

        /// <summary> 获取对象(Offset) 不同类型的 Value 值 </summary>
        Object GetOffsetValue(Object offset)
        {
            var pp = offset.GetType().GetProperty("Value");
            var vv = pp.GetValue(offset);

            return vv;
        }

        void UpdateDeltaObject(String key, Object rawValue)
        {
            Regex rgx = new Regex(@"^\d.*\.*\d$");
            Object result;
            if (rgx.IsMatch(rawValue.ToString()))
                result = Calculation.CalculateValue(key, rawValue);
            else
                result = rawValue;

            if (previousValues.ContainsKey(key))
            {
                if (previousValues[key].ToString() == result.ToString())
                    deltaValues.Remove(key);
                else
                {
                    deltaValues[key] = result;
                    previousValues[key] = result;
                }
            }
            else
            {
                deltaValues.Add(key, result);
                previousValues.Add(key, result);
            }
        }

        void GetFullObject()
        {
            try
            {
                FSUIPCConnection.Process();
                FieldInfo[] myField = typeof(FSUIData).GetFields(BindingFlags.Public | BindingFlags.Static);
                var fullObject = new Dictionary<String, Object>();

                foreach (var fd in myField)
                {
                    var obj = fd.GetValue(null); // Offset<Type> 对象
                    fullObject.Add(fd.Name, GetOffsetValue(obj));
                }
                if((JsonConvert.SerializeObject(deltaValues, Formatting.None) != "{}"))
                {
                    // 公布 JSon 对象
                    wssv.WebSocketServices.Broadcast(JsonConvert.SerializeObject(fullObject, Formatting.None));
                }
            }
            catch (Exception ex) {
                ConfigureForm();
                txtJson.Text = ex.Message;
            }
        }

        #endregion

        #region Message Event

        private void TimerConnection_Tick(Object sender, EventArgs e)
        {
            try
            {
                FSUIPCConnection.Open();
                // 如果连接上 FSUIPC 就停止
                timerConnection.Stop();
                timerMain.Start();
                GetFullObject();
                // 更新显示状态
                ConfigureForm();  
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        private void TimerMain_Tick(Object sender, EventArgs e)
        {
            // Call process() to read/ write data to/ from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIData.DME_SWITCH.Value = (ushort)FSUIPCConnection.ReadLVar("DME_Switch");

                FSUIPCConnection.Process(); // 有这句就可以更新数据了

                chkAvionicsMaster.IsChecked = (FSUIData.AvionicsMaster.Value > 0);

                FieldInfo[] myField = typeof(FSUIData).GetFields(BindingFlags.Public | BindingFlags.Static);

                foreach(var fd in myField)
                {
                    var obj = fd.GetValue(null); // 获取静态 Field, 否则用 Instance 最为参数
                    UpdateDeltaObject(fd.Name, GetOffsetValue(obj));
                }

                if (chkShowValues.IsChecked == true)
                {
                    txtPrevious.Text = JsonConvert.SerializeObject(previousValues, Formatting.Indented);
                    txtJson.Text = JsonConvert.SerializeObject(deltaValues, Formatting.Indented);
                }
                else
                {
                    txtPrevious.Text = "";
                    txtJson.Text = "";
                }

                if (JsonConvert.SerializeObject(deltaValues, Formatting.None) != "{}") {
                    // 请求更新数据内容
                    if (chkSendFull.IsChecked == true)
                        wssv.WebSocketServices.Broadcast(JsonConvert.SerializeObject(previousValues, Formatting.None));
                    else
                        wssv.WebSocketServices.Broadcast(JsonConvert.SerializeObject(deltaValues, Formatting.None));
                }
            }
            catch(Exception ex)
            {
                timerMain.Stop();
                txtJson.Text = ex.Message;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timerConnection.Stop();
            timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void btnOpenUrl_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + System.Environment.MachineName.ToString() + ":"
                + Config["webserver"]["port"].ToString());
        }

        private void chkAvionicsMaster_Click(object sender, RoutedEventArgs e)
        {
            FSUIData.AvionicsMaster.Value = chkAvionicsMaster.IsChecked.Value ? 1u : 0u;
        }

        #endregion
    }
}
