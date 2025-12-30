using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtils
{
    public class Settings
    {
        public static int RECODE_SUCCEED                      = 1   ;
        public static int RECODE_FAILURE                      = 0   ;
        public static int RECODE_WARNING                      = 2   ;
        public static int CODE_SUCCESS                        = 200 ;
        public static int CODE_FAILURE                        = 500 ;
        public static int CODE_WARNING                        = 201 ;
        public static int AXIS_STATUS_REGISTER_0              = 0   ;
        public static int AXIS_STATUS_REGISTER_1              = 1   ;
        public static int AXIS_STATUS_REGISTER_2              = 2   ;
        public static int AXIS_STATUS_REGISTER_3              = 3   ;
        public static int AXIS_STATUS_REGISTER_4              = 4   ;
        public static int READONLY_AXIS_STATUS_REGISTER_0     = 0   ;
        public static int READONLY_AXIS_STATUS_REGISTER_1     = 1   ;
        public static int READONLY_AXIS_STATUS_REGISTER_2     = 2   ;
        public static int READONLY_AXIS_STATUS_REGISTER_3     = 3   ;
        public static int READONLY_AXIS_STATUS_REGISTER_4     = 4   ;
        public static int READONLY_AXIS_STATUS_REGISTER_5     = 5   ;
        public static byte[] START_DECODE       = { 0x16, 0x54, 0x0D };
        public static byte[] STOP_DECODE        = { 0x16, 0x55, 0x0D };
        public static byte[] CONSOLE_MODE       = { 0x16, 0x4D, 0x0D, 0x30, 0x34, 0x30, 0x31, 0x44, 0x30, 0x35, 0x2E };
        public static byte[] GET_VERSION        = { 0x16, 0x4D, 0x0D, 0x25, 0x25, 0x25, 0x56, 0x45, 0x52, 0x2E };
        public static byte[] DECODE_TAIL        = { 0x0D, 0x0A};
        public static byte[] DECODE_FRAME_TAIL  = { 0x06 };
        public static int    DEFAULT_RESULT_INT     = default(int       );
        public static string DEFAULT_RESULT_STR     = default(string    );
    }
}
