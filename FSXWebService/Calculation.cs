using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NCalc;
using Newtonsoft.Json;

namespace FSXWebService
{
    

    class Calculation
    {
        readonly static Dictionary<String, String> ValueRecalculation = new Dictionary<string, string>() {
            {"IAS", "x / 128"},
            {"TAS", "x / 128"},
            {"VS",  "x / 256"},
            {"GS",  "x / 65536"},
            {"AoA", "x * 57.3"},
            {"Beta","x * 57.3"},
            {"GPS_HEADING","x * 57.3"},
            {"GPS_TRACK","x * 57.3"},
            {"GPS_DTK","x * 57.3"},
            {"ADF1_Bearing", "x * (360 / 65536)"},
            {"ADF2_Bearing", "x * (360 / 65536)"},
            {"PLANE_HEADING_DEGREES_MAGNETIC", "x * (360 / 65536 / 65536)"},
            {"PLANE_BANK_DEGREES", "x * (360 / 65536 / 65536) - 360"},
            {"PLANE_PITCH_DEGREES", "x * (360 / 65536 / 65536)"},
            {"TURB_ENG_1_ITT", "(x - 491.67) * 5/9"},
            {"TURB_ENG_2_ITT", "(x - 491.67) * 5/9"},
            {"GEAR_LEFT_POSITION",   "x/163.83"},
            {"GEAR_CENTER_POSITION", "x/163.83"},
            {"GEAR_RIGHT_POSITION",  "x/163.83"},
            {"AUTOPILOT_HEADING_LOCK_DIR", "x / 65536 * 360"},
            {"AUTOPILOT_ALTITUDE_LOCK_VAR", "x * 3.28084 / 65536"},
            {"NAV_1_DME_DISTANCE", "x / 10"},
            {"NAV_1_DME_SPEED", "x / 10"},
            {"NAV_1_DME_TIMETO", "x / 10"},
            {"NAV_2_DME_DISTANCE", "x / 10"},
            {"NAV_2_DME_SPEED", "x / 10"},
            {"NAV_2_DME_TIMETO", "x / 10"},
            {"ELEVATOR_TRIM_POSITION", "x / 163.83"},
            {"TRAILING_EDGE_FLAPS_LEFT_PERCENT", "x / 163.83"},
            {"TRAILING_EDGE_FLAPS_RIGHT_PERCENT", "x / 163.83"},
            {"GENERAL_ENG_1_OIL_TEMPERATURE", "x / 117.0285714285714"},
            {"GENERAL_ENG_2_OIL_TEMPERATURE", "x / 117.0285714285714"},
        };

        public static Object CalculateValue(String key, Object rawValue)
        {
            Object returnValue = rawValue;

            if(ValueRecalculation.ContainsKey(key))
            {
                var szExpress = ValueRecalculation[key].Replace("x", rawValue.ToString());
                var express = new NCalc.Expression(szExpress);
                decimal tmp = Convert.ToDecimal(express.Evaluate());
                returnValue = Math.Round(tmp, 2);
            }
            return returnValue;
        }
    }
}
