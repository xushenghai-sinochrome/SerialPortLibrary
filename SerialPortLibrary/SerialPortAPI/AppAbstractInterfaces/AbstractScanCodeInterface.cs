using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using AppUtils;
namespace AppInterfaces
{
    public abstract class AbstractScanCodeInterface: Appinterface, ScanCodeInterface
    {
        protected SerialPort    Manager     = null;
        protected SerialContext Parameter   = null;
        protected static readonly object IOLocker = new object();
        public          bool    hasManager     { get {return Manager    != null         ;} }
        public          bool    hasParameter   { get {return Parameter  != null         ;} }
        public          bool    IsValid        { get {return hasManager && hasParameter ;} }
        public          bool    IsAvailable    { get {return IsValid && IsOpen          ;} }
        public          bool    IsOpen         { get {return IsValid && Manager.IsOpen  ;} }
        public string MethodWaitDone(ScanCodeInterface manager, string buffer, string frameTail, int timeout = 100, int waittime = 50) {
            try
            {
                if (manager != null)
                {
                    return manager.WaitDone(buffer, frameTail, timeout, waittime);
                }
            }
            catch (Exception) { }
            return default(string);
        }
        public byte[] MethodWaitDone(ScanCodeInterface manager, byte[] buffer, string frameTail, int timeout = 100, int waittime = 50) {
            try
            {
                if (manager != null)
                {
                    return manager.WaitDone(buffer, frameTail, timeout, waittime);
                }
            }
            catch (Exception) { }
            return default(byte[]);
        }
        public int     ReOpen         ()
        {
            Close();
            return Open();
        }
        public int     Open           ()
        {
            int isWarning = Settings.RECODE_FAILURE;
            initParameter();
            if (!IsValid) initManager();
            if (IsOpen) Close();
            isWarning = SerialPortUtil.Open(Manager, Parameter);
            return isWarning;
        }
        public int     Close          ()
        {
            int isWarning = Settings.RECODE_SUCCEED;
            if (!hasManager || !IsOpen)
                return isWarning;
            isWarning = SerialPortUtil.Close(Manager);
            return isWarning;
        }
        public void    initManager    ()
        {
            
            if(!hasManager)
            {
                Manager = new SerialPort();
                initParameter();
                Manager.PortName        =           Parameter.PortName              ;
                Manager.BaudRate        =           Parameter.BaudRate              ;
                Manager.DataBits        =           Parameter.DataBits              ;
                Manager.StopBits        = (StopBits)Parameter.StopBits              ;
                Manager.Parity          = (Parity)  Parameter.Parity                ;
                Manager.ReadTimeout     =           Parameter.ReadTimeout           ;
                Manager.WriteTimeout    =           Parameter.SendTimeout           ;
            }
        }
        public void    deleManager    ()
        {
            Close();
            try
            {
                if (hasManager)
                    Manager.Dispose();
                Manager = null;
                GC.Collect();
            }
            catch (Exception) { }
        }
        public void    initParameter  ()
        {
            if (!hasParameter)
            {
                Parameter = new SerialContext();
            }
        }
        public void    deleParameter  ()
        {
            try
            {
                Parameter = null;
                GC.Collect();
            }
            catch (Exception) { }
        }
        public void    setParameter(string portname, int baudrate, int databits = 8, int stopbits = 1, int parity = 0)
        {
            if (!hasParameter)
                initParameter();
            Parameter.PortName              = portname  ;
            Parameter.BaudRate              = baudrate  ;
            Parameter.DataBits              = databits  ;
            Parameter.StopBits              = stopbits  ;
            Parameter.Parity                = parity    ;
        }
        public string  ReadString  (string frameTail, int timeout = 100)
        {
            if (!IsValid) initManager();
            if (!IsOpen) Open();
            return SerialPortUtil.ReadString(Manager, frameTail, timeout);
        }
        public byte[]  ReadBinary  (string frameTail, int timeout = 100)
        {
            if (!IsValid) initManager();
            if (!IsOpen) Open();
            return SerialPortUtil.ReadBinary(Manager, frameTail, timeout);
        }
        public int     SendString  (string buffer)
        {
            if (!IsValid) initManager();
            if (!IsOpen) Open();
            return SerialPortUtil.SendString(Manager, buffer);
        }
        public int     SendBinary  (byte[] buffer)
        {
            if (!IsValid) initManager();
            if (!IsOpen) Open();
            return SerialPortUtil.SendBinary(Manager, buffer);
        }
        public string  WaitDone    (string buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            lock(IOLocker)
            {
                if (!IsValid) initManager();
                if (!IsOpen) Open();
                int isWarning = SerialPortUtil.SendString(Manager, buffer);
                if(Settings.RECODE_SUCCEED == isWarning)
                {
                    AppTimeLoop.ProcessEvents(waittime);
                    return SerialPortUtil.ReadString(Manager, frameTail, timeout);
                }

            }
            return default(string);
        }
        public byte[]  WaitDone    (byte[] buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            lock(IOLocker)
            {
                if (!IsValid) initManager();
                if (!IsOpen) Open();
                int isWarning = SerialPortUtil.SendBinary(Manager, buffer);
                if (Settings.RECODE_SUCCEED == isWarning)
                {
                    AppTimeLoop.ProcessEvents(waittime);
                    return SerialPortUtil.ReadBinary(Manager, frameTail, timeout);
                }
            }
            return default(byte[]);
        }
        public string  ScanCode        (int timeout = 1000, int waittime = 50  )
        {
            try
            {
                byte[] buffer = WaitDone(Settings.START_DECODE, Encoding.UTF8.GetString(Settings.DECODE_TAIL), timeout, waittime);
                return Encoding.UTF8.GetString(buffer);
            }
            catch (Exception) { }
            return default(string);
        }
        public void    StopScanCode    (int timeout = 1000, int waittime = 50  )
        {
            try
            {
                byte[] buffer = WaitDone(Settings.STOP_DECODE, Encoding.UTF8.GetString(Settings.DECODE_TAIL), timeout, waittime);
            }
            catch (Exception) { }
            return ;
        }
        public string  SetHostMode     (int timeout = 1000, int waittime = 50  )
        {
            try
            {
                byte[] buffer = WaitDone(Settings.CONSOLE_MODE, Encoding.UTF8.GetString(Settings.DECODE_FRAME_TAIL), timeout, waittime);
                return Encoding.UTF8.GetString(buffer);
            }
            catch (Exception) { }
            return default(string);
        }
        public string  GetVersion      (int timeout = 1000, int waittime = 50  )
        {
            try
            {
                byte[] buffer = WaitDone(Settings.GET_VERSION, Encoding.UTF8.GetString(Settings.DECODE_FRAME_TAIL), timeout, waittime);
                return Encoding.UTF8.GetString(buffer);
            }
            catch (Exception) { }
            return default(string);
        }
        public void ClearBuffer     (                                       )
        {
            ReadString(null, 500);
        }

        public abstract ScanCodeInterface Instance        ();
        
        
    }
}
