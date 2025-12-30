using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces;
using AppUtils;
namespace LeiCaMicroscopeAPI
{
    public class ScanCodeController
    {
        public static ScanCodeInterface Instance()
        {
            return new ScanCodeReader();
        }
        public static int     Open           (ScanCodeInterface manager)
        {
            try
            {
                return manager.Open();
            }
            catch (Exception) { }
            return Settings.RECODE_FAILURE;
        }
        public static int     Close             (ScanCodeInterface manager)
        {
            try
            {
                return manager.Close();
            }
            catch (Exception) { }
            return Settings.RECODE_FAILURE;
        }
        public static int     ReOpen            (ScanCodeInterface manager)
        {
            try
            {
                return manager.ReOpen();
            }
            catch (Exception) { }
            return Settings.RECODE_FAILURE;
        }
        public static void    initManager       (ScanCodeInterface manager)
        {
            try
            {
                manager.initManager();
            }
            catch (Exception) { }
            return ;
        }
        public static void    initParameter     (ScanCodeInterface manager)
        {
            try
            {
                manager.initParameter();
            }
            catch (Exception) { }
            return;
        }

        public static string  ReadString        (ScanCodeInterface manager, string frameTail, int timeout = 100)
        {
            try
            {
                return manager.ReadString(frameTail, timeout);
            }
            catch (Exception) { }
            return default(string);
        }
        public static byte[]  ReadBinary        (ScanCodeInterface manager, string frameTail, int timeout = 100)
        {
            try
            {
                return manager.ReadBinary(frameTail, timeout);
            }
            catch (Exception) { }
            return default(byte[]);
        }
        public static int     SendString        (ScanCodeInterface manager, string buffer)
        {
            try
            {
                return manager.Open();
            }
            catch (Exception) { }
            return Settings.RECODE_FAILURE;
        }
        public static int     SendBinary        (ScanCodeInterface manager, byte[] buffer)
        {
            try
            {
                return manager.Open();
            }
            catch (Exception) { }
            return Settings.RECODE_FAILURE;
        }
        public static string  WaitDone          (ScanCodeInterface manager, string buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            try
            {
                return manager.WaitDone(buffer, frameTail, timeout, waittime);
            }
            catch (Exception) { }
            return default(string);
        }
        public static byte[]  WaitDone          (ScanCodeInterface manager, byte[] buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            try
            {
                return manager.WaitDone(buffer, frameTail, timeout, waittime);
            }
            catch (Exception) { }
            return default(byte[]);
        }
        

        public static string ScanCode        (ScanCodeInterface manager, int timeout = 1000, int waittime = 50  )
        {
            try
            {
                return manager.ScanCode(timeout, waittime);
            }
            catch (Exception) { }
            return default(string);
        }
        public static void StopScanCode    (ScanCodeInterface manager, int timeout = 1000, int waittime = 50  )
        {
            try
            {
                manager.StopScanCode(timeout, waittime);
            }
            catch (Exception) { }
            return ;
        }
        public static string SetHostMode     (ScanCodeInterface manager, int timeout = 1000, int waittime = 50  )
        {
            try
            {
                return manager.SetHostMode(timeout, waittime);
            }
            catch (Exception) { }
            return default(string);
        }
        public static string GetVersion      (ScanCodeInterface manager, int timeout = 1000, int waittime = 50  )
        {
            try
            {
                return manager.GetVersion(timeout, waittime);
            }
            catch (Exception) { }
            return default(string);
        }
        public static void ClearBuffer     (ScanCodeInterface manager)
        {
            try
            {
                manager.ClearBuffer();
            }
            catch (Exception) { }
            return ;
        }
    }
}
