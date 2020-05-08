using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSUIPC;


namespace FSXWebService
{
    class FSUIData
    {
        static public Offset<string> Title  = new Offset<string>(0x3D00, 256);
        static public Offset<string> ATC_ID = new Offset<string>(0x313C, 12);
        static public Offset<UInt32> INDICATED_ALTITUDE = new Offset<UInt32>(0x3324);
        static public Offset<UInt32> AIRSPEED_INDICATED = new Offset<UInt32>(0x2BC);
        static public Offset<UInt32> AvionicsMaster = new Offset<UInt32>(0x2E80);
        static public Offset<UInt32> PLANE_HEADING_DEGREES_MAGNETIC = new Offset<UInt32>(0x580);
        static public Offset<UInt32> PLANE_BANK_DEGREES = new Offset<UInt32>(0x57C);
        static public Offset<UInt32> PLANE_PITCH_DEGREES = new Offset<UInt32>(0x578);
        static public Offset<Int32>  VERTICAL_SPEED = new Offset<Int32>(0x2C8);
        static public Offset<float>  NAV_1_CDI = new Offset<float>(0x2AAC);
        static public Offset<float>  NAV_1_GSI = new Offset<float>(0x2AB0);
        static public Offset<float>  NAV_2_CDI = new Offset<float>(0x2AB4);
        static public Offset<float>  NAV_2_GSI = new Offset<float>(0x2AB8);
        static public Offset<float>  ENG_1_TORQUE = new Offset<float>(0x920);
        static public Offset<float>  ENG_2_TORQUE = new Offset<float>(0x9B8);
        static public Offset<float>  ENG_3_TORQUE = new Offset<float>(0xA50);
        static public Offset<float>  ENG_4_TORQUE = new Offset<float>(0xAE8);
        static public Offset<double> TURB_ENG_1_ITT = new Offset<double>(0x2038);
        static public Offset<double> TURB_ENG_2_ITT = new Offset<double>(0x2138);
        static public Offset<double> TURB_ENG_3_ITT = new Offset<double>(0x2238);
        static public Offset<double> TURB_ENG_4_ITT = new Offset<double>(0x2338);
        static public Offset<UInt32> GEAR_LEFT_POSITION = new Offset<UInt32>(0xBF4);
        static public Offset<UInt32> GEAR_CENTER_POSITION = new Offset<UInt32>(0xBEC);
        static public Offset<UInt32> GEAR_RIGHT_POSITION = new Offset<UInt32>(0xBF0);
        static public Offset<UInt32> AUTOPILOT_AVAILABLE = new Offset<UInt32>(0x764);
        static public Offset<UInt32> AUTOPILOT_MASTER = new Offset<UInt32>(0x7BC);
        static public Offset<UInt32> AUTOPILOT_HEADING_LOCK = new Offset<UInt32>(0x7C8);
        static public Offset<UInt32> AUTOPILOT_HEADING_LOCK_DIR = new Offset<UInt32>(0x7CC);
        static public Offset<UInt32> AUTOPILOT_NAV1_LOCK = new Offset<UInt32>(0x7C4);
        static public Offset<UInt32> AUTOPILOT_APR_LOCK = new Offset<UInt32>(0x800);
        static public Offset<UInt32> AUTOPILOT_GS_LOCK = new Offset<UInt32>(0x7FC);
        static public Offset<UInt32> AUTOPILOT_FD_LOCK = new Offset<UInt32>(0x2EE0);
        static public Offset<UInt32> AUTOPILOT_BACKCOURSE_LOCK = new Offset<UInt32>(0x804);
        static public Offset<UInt32> AUTOPILOT_YAW_DAMPER = new Offset<UInt32>(0x808);
        static public Offset<UInt32> AUTOPILOT_ATTITUDE_LOCK = new Offset<UInt32>(0x7D8);
        static public Offset<UInt32> AUTOPILOT_ALTITUDE_LOCK = new Offset<UInt32>(0x7D0);
        static public Offset<UInt32> AUTOPILOT_ALTITUDE_LOCK_VAR = new Offset<UInt32>(0x7D4);
        static public Offset<UInt32> AUTOPILOT_AIRSPEED_LOCK = new Offset<UInt32>(0x7D0);
        static public Offset<UInt32> AUTOPILOT_AIRSPEED_LOCK_KNOTS = new Offset<UInt32>(0x7E2);
        static public Offset<UInt32> AUTOPILOT_VERTICALSPEED_LOCK = new Offset<UInt32>(0x7EC);
        static public Offset<UInt32> AUTOPILOT_VERTICALSPEED_LOCK_KNOTS = new Offset<UInt32>(0x7F2);
        static public Offset<UInt32> AUTOPILOT_APPROACH_HOLD = new Offset<UInt32>(0x800);
        static public Offset<UInt32> AUTOTHROTTLE_ARM = new Offset<UInt32>(0x810);
        static public Offset<ushort> DME_SWITCH = new Offset<ushort>(0x66C0);
        static public Offset<ushort> NAV_1_DME_DISTANCE = new Offset<ushort>(0x300);
        static public Offset<ushort> NAV_1_DME_SPEED = new Offset<ushort>(0x302);
        static public Offset<ushort> NAV_1_DME_TIMETO = new Offset<ushort>(0x304);
        static public Offset<ushort> NAV_2_DME_DISTANCE = new Offset<ushort>(0x306);
        static public Offset<ushort> NAV_2_DME_SPEED = new Offset<ushort>(0x308);
        static public Offset<ushort> NAV_2_DME_TIMETO = new Offset<ushort>(0x30A);
        static public Offset<ushort> ELEVATOR_TRIM_POSITION = new Offset<ushort>(0xBC2);
        static public Offset<Int32>  TRAILING_EDGE_FLAPS_LEFT_PERCENT = new Offset<Int32>(0xBE0);
        static public Offset<Int32>  TRAILING_EDGE_FLAPS_RIGHT_PERCENT = new Offset<Int32>(0xBE4);
        static public Offset<ushort> GENERAL_ENG_1_OIL_PRESSURE = new Offset<ushort>(0x8BA);
        static public Offset<ushort> GENERAL_ENG_2_OIL_PRESSURE = new Offset<ushort>(0x952);
        static public Offset<ushort> GENERAL_ENG_3_OIL_PRESSURE = new Offset<ushort>(0x9EA);
        static public Offset<ushort> GENERAL_ENG_4_OIL_PRESSURE = new Offset<ushort>(0xA82);
        static public Offset<ushort> GENERAL_ENG_1_OIL_TEMPERATURE = new Offset<ushort>(0x8B8);
        static public Offset<ushort> GENERAL_ENG_2_OIL_TEMPERATURE = new Offset<ushort>(0x950);
        static public Offset<ushort> GENERAL_ENG_3_OIL_TEMPERATURE = new Offset<ushort>(0x9E8);
        static public Offset<ushort> GENERAL_ENG_4_OIL_TEMPERATURE = new Offset<ushort>(0xA80);
        static public Offset<short>  LIGHTS = new Offset<short>(0xD0C);
    }
}
