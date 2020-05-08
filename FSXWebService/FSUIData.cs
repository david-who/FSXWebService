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
        static public Offset<UInt32> INDICATED_ALTITUDE = new Offset<UInt32>(0x3324); // This is the altimeter reading in feet

        static public Offset<UInt32> GS  = new Offset<UInt32>(0x02B4);                // GS:  Ground Speed, as 65536*metres/sec.
        static public Offset<UInt32> TAS = new Offset<UInt32>(0x02B8);                // TAS: True Air Speed, as knots * 128
        static public Offset<UInt32> IAS = new Offset<UInt32>(0x02BC);                // IAS: Indicated Air Speed, as knots * 128
        static public Offset<Int32>  VS  = new Offset<Int32>(0x02C8);                 // Vertical speed, signed, as 256 * metres/sec
        static public Offset<double> MagHeading = new Offset<double>(0x02CC);         // Whiskey Compass, degrees in double
        static public Offset<double> Mach = new Offset<double>(0x35A0);               // Airspeed Mach value, double float.
        static public Offset<double> PressureAltitude = new Offset<double>(0x34B0);   // Pressure Altitude (metres), double float.
        static public Offset<double> AoA  = new Offset<double>(0x2ED0);               // Incidence alpha, in radians, as a double (FLOAT64). 
        static public Offset<double> Beta = new Offset<double>(0x2ED8);               // Incidence beta, in radians, as a double (FLOAT64).
        static public Offset<double> Gmax = new Offset<double>(0x34D0);               // G force maximum
        static public Offset<double> Gmin = new Offset<double>(0x34D8);               // G force minimum
        static public Offset<double> ENG1_EGT = new Offset<double>(0x34D8);           // General engine 1 EGT in degrees Rankine, as a double (FLOAT64).
                                                                                      //   Convert to Fahrenheit by Rankine – 459.67. FS default gauges show Centigrade.
        static public Offset<double> ENG2_EGT = new Offset<double>(0x3AB0);           // General engine 2 EGT in degrees Rankine, as a double (FLOAT64).
        static public Offset<double> ENG1_ITT = new Offset<double>(0x2038);           // Turbine Engine 1 ITT (interstage turbine temperature) in degrees Rankine, as a double (FLOAT64).
        static public Offset<double> ENG2_ITT = new Offset<double>(0x2138);           // Turbine Engine 2 ITT

        static public Offset<double> GPS_LAT = new Offset<double>(0x6010);            // GPS: aircraft latitude, floating point double, in degrees (+ve = N, –ve = S).
        static public Offset<double> GPS_LON = new Offset<double>(0x6018);            // GPS: aircraft longitude, floating point double, in degrees (+ve = E, –ve = W).
        static public Offset<double> GPS_ALT = new Offset<double>(0x6020);            // GPS: aircraft altitude, floating point double, in metres.
        static public Offset<double> GPS_VAR = new Offset<double>(0x6028);            // GPS: magnetic variation at aircraft, floating point double, in radians
        static public Offset<double> GPS_GS  = new Offset<double>(0x6030);            // GPS: aircraft ground speed, floating point double, metres per second.
        static public Offset<double> GPS_HEADING = new Offset<double>(0x6038);        // GPS: aircraft true heading, floating point double, in radians.
        static public Offset<double> GPS_TRACK = new Offset<double>(0x6040);          // GPS: aircraft magnetic track, floating point double, in radians.
        static public Offset<double> GPS_DST = new Offset<double>(0x6048);            // GPS: distance to next waypoint, floating point double, in metres.
        static public Offset<double> GPS_DTK = new Offset<double>(0x6050);            // GPS: magnetic bearing to next waypoint, floating point double, in radians.

        static public Offset<UInt32> AvionicsMaster = new Offset<UInt32>(0x2E80);
        static public Offset<UInt32> PLANE_HEADING_DEGREES_MAGNETIC = new Offset<UInt32>(0x580);
        static public Offset<UInt32> PLANE_BANK_DEGREES = new Offset<UInt32>(0x57C);
        static public Offset<UInt32> PLANE_PITCH_DEGREES = new Offset<UInt32>(0x578);
        static public Offset<ushort> DME_SWITCH = new Offset<ushort>(0x66C0);
        static public Offset<short> ADF1_Bearing = new Offset<short>(0x0C6A);        // ADF1: relative bearing to NDB ( *360/65536 for degrees, –ve left, +ve right)
        static public Offset<short> ADF2_Bearing = new Offset<short>(0x02D8);        // ADF2: relative bearing to NDB ( *360/65536 for degrees, –ve left, +ve right)

        static public Offset<ushort> NAV_1_DME_DISTANCE = new Offset<ushort>(0x300);
        static public Offset<ushort> NAV_1_DME_SPEED = new Offset<ushort>(0x302);
        static public Offset<ushort> NAV_1_DME_TIMETO = new Offset<ushort>(0x304);
        static public Offset<ushort> NAV_2_DME_DISTANCE = new Offset<ushort>(0x306);
        static public Offset<ushort> NAV_2_DME_SPEED = new Offset<ushort>(0x308);
        static public Offset<ushort> NAV_2_DME_TIMETO = new Offset<ushort>(0x30A);
        static public Offset<float>  NAV_1_CDI = new Offset<float>(0x2AAC);
        static public Offset<float>  NAV_1_GSI = new Offset<float>(0x2AB0);
        static public Offset<float>  NAV_2_CDI = new Offset<float>(0x2AB4);
        static public Offset<float>  NAV_2_GSI = new Offset<float>(0x2AB8);
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
        static public Offset<Int32>  TRAILING_EDGE_FLAPS_LEFT_PERCENT = new Offset<Int32>(0xBE0);
        static public Offset<Int32>  TRAILING_EDGE_FLAPS_RIGHT_PERCENT = new Offset<Int32>(0xBE4);
        static public Offset<ushort> ELEVATOR_TRIM_POSITION = new Offset<ushort>(0xBC2);

        static public Offset<short>  ENG_1_N1 = new Offset<short>(0x0898);                   // Engine 1 Jet N1 as 0 – 16384 (100%), or Prop RPM ( by * RPM Scaler / 65536).
        static public Offset<short>  ENG_1_N2 = new Offset<short>(0x0896);                   // Engine 1 Jet N2 as 0 – 16384 (100%), or to be the Turbine RPM % for proper helo models
        static public Offset<short>  ENG_1_RPM_K = new Offset<short>(0x0898);                // Engine 1 RPM Scaler: For Props, use this to calculate RPM
        static public Offset<ushort> ENG_1_OIL_TEMPERATURE = new Offset<ushort>(0x08B8);     // Engine 1 Oil temperature, 16384 = 140 C.
        static public Offset<ushort> ENG_1_OIL_PRESSURE = new Offset<ushort>(0x08BA);        // Engine 1 Oil pressure, 16384 = 55 psi
        static public Offset<ushort> ENG_1_EGT = new Offset<ushort>(0x08BE);                 // Engine 1 EGT, 16384 = 860 C
        static public Offset<UInt32> ENG_1_HYD_PRESSURE = new Offset<UInt32>(0x08D8);        // Engine 1 Hydraulic pressure: appears to be 4*psi
        static public Offset<UInt32> ENG_1_FUEL_PRESSURE = new Offset<UInt32>(0x08F8);       // Engine 1 Fuel pressure, psf (i.e. psi*144)
        static public Offset<double> ENG_1_CHT = new Offset<double>(0x08E8);                 // Engine 1 CHT, degrees F in double floating point (FLOAT64)
        static public Offset<float>  ENG_1_TORQUE = new Offset<float>(0x0920);               // 08F4

        static public Offset<short>  ENG_2_N1 = new Offset<short>(0x0930);                   // Engine 2 Jet N1 as 0 – 16384 (100%), or Prop RPM ( by * RPM Scaler / 65536).
        static public Offset<short>  ENG_2_N2 = new Offset<short>(0x092E);                   // Engine 2 Jet N2 as 0 – 16384 (100%), or to be the Turbine RPM % for proper helo models
        static public Offset<short>  ENG_2_RPM_K = new Offset<short>(0x0060);                // Engine 2 RPM Scaler: For Props, use this to calculate RPM
        static public Offset<ushort> ENG_2_OIL_TEMPERATURE = new Offset<ushort>(0x0950);     // Engine 2 Oil temperature, 16384 = 140 C.
        static public Offset<ushort> ENG_2_OIL_PRESSURE = new Offset<ushort>(0x0952);
        static public Offset<ushort> ENG_2_EGT = new Offset<ushort>(0x0956);                 // Engine 2 EGT, 16384 = 860 C
        static public Offset<UInt32> ENG_2_HYD_PRESSURE = new Offset<UInt32>(0x0970);        // Engine 2 Hydraulic pressure: appears to be 4*psi
        static public Offset<UInt32> ENG_2_FUEL_PRESSURE = new Offset<UInt32>(0x0990);       // Engine 2 Fuel pressure, psf (i.e. psi*144)
        static public Offset<double> ENG_2_CHT = new Offset<double>(0x0980);                 // Engine 2 CHT, degrees F in double floating point (FLOAT64)
        static public Offset<float>  ENG_2_TORQUE = new Offset<float>(0x09B8);

        static public Offset<short>  LIGHTS = new Offset<short>(0xD0C);
    }
}
