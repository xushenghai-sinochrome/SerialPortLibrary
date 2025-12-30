using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using AppInterfaces;
using AppUtils;
namespace LeiCaMicroscopeAPI
{
    public abstract class AbstractLMicroscope: Appinterface, ILMicroscopeInterface
    {
        public abstract ILMicroscopeInterface Instance();
        protected SerialPort    Manager     = null;
        protected LeiCaContext  Parameter   = null;
        protected static readonly object IOLocker = new object();
        public          bool    hasManager     { get {return Manager    != null         ;} }
        public          bool    hasParameter   { get {return Parameter  != null         ;} }
        public          bool    IsValid        { get {return hasManager && hasParameter ;} }
        public          bool    IsAvailable    { get {return IsValid && IsOpen          ;} }
        public          bool    IsOpen         { get {return IsValid && Manager.IsOpen  ;} }
        public SerialPort manager { get { return Manager; } }
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
                Parameter = new LeiCaContext();
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
        /*=====================================================================================================================*/
        public abstract int                             setMasterEvents                     (                           );
        public abstract int                             setZDriveEvents                     (                           );
        public abstract int                             setObjectiveEvents                  (                           );
        public abstract int                             setTLFieldEvents                    (                           );
        public abstract int                             setTLEvents                         (                           );
        public abstract int                             setSpotLightEvents                  (                           );
        public abstract int                             setMasterReset                      (                           );
        public abstract int                             setMasterDefault                    (                           );
        public abstract int                             setMasterConfigMode                 (bool enable                );
        public abstract int                             setMasterWaitTimes                  (int  waittimes             );
        public abstract int                             setManualOptionStatus               (bool enable                );
        public abstract (int, int)                      getMicroscopeInitStatus             (                           );
        public abstract (int, int)                      getMasterFirmwareStatus             (                           );
        public abstract (int, int)                      getMasterConfigMode                 (                           );
        public abstract (int, int)                      getManualOptionStatus               (                           );

        /*=====================================================================================================================*/
        public abstract int                             setZDriverManualOptionStatus        (bool enable                );
        public abstract int                             setZDriverReset                     (                           );
        public abstract int                             setZDriverInit                      (                           );
        public abstract int                             setZDriverBreak                     (                           );
        public abstract int                             setZDriverAbsPosition               (int value                  );
        public abstract int                             setZDriverRelPosition               (int value                  );
        public abstract int                             setZDriverConstPosition             (int value                  );
        public abstract int                             setZDriverLowerLimit                (int value                  );
        public abstract int                             setZDriverFocusLimit                (int value                  );
        public abstract int                             setZDriverUpperLimit                (int value                  );
        public abstract int                             setZDriverAcceleration              (int value                  );
        public abstract int                             setZDriverSpeed                     (int value                  );
        public abstract int                             ZDriverMoveToFocusLimit             (                           );
        public abstract int                             ZDriverMoveToLowerLimit             (                           );
        public abstract int                             ZDriverPositionAsFocus              (                           );
        public abstract int                             ZDriverPositionAsLower              (                           );
        public abstract int                             ZDriverInitRange                    (                           );
        public abstract int                             setZDriverMoveMode                  (bool enable                );
        public abstract int                             setZDriverFocusLimitEnable          (bool enable                );
        public abstract int                             setZDriverInitMode                  (string value               );
        public abstract (int, int, int, int, int, int)  getZDriverStatus                    (                           );
        public abstract (int,           int     )       getZDriverManualOptionStatus        (                           );
        public abstract (int,           int     )       getZDriverFirmwareStatus            (                           );
        public abstract (int,           int     )       getZDriverAbsPosition               (                           );
        public abstract (int,           int     )       getZDriverLowerLimit                (                           );
        public abstract (int,           int     )       getZDriverFocusLimit                (                           );
        public abstract (int,           int     )       getZDriverAcceleration              (                           );
        public abstract (int,           int     )       getZDriverSpeed                     (                           );
        public abstract (int,           int     )       getZDriverConvertFactor             (                           );
        public abstract (int,           int     )       getZDriverMinAcceleration           (                           );
        public abstract (int,           int     )       getZDriverMaxAcceleration           (                           );
        public abstract (int,           int     )       getZDriverMoveMode                  (                           );
        public abstract (int,           int     )       getZDriverFocusLimitEnable          (                           );
        public abstract (int,           int     )       getZDriverMinSpeed                  (                           );
        public abstract (int,           int     )       getZDriverMaxSpeed                  (                           );
        public abstract (int,           int     )       getZDriverUpperLimit                (                           );
        public abstract (int,           string  )       getZDriverInitMode                  (                           );
        /*===============================================物镜操作方法======================================================================*/
        public abstract int                             setObjectiveManualOperation         (bool           value       );
        public abstract int                             setObjectiveAbsPosition             (int            value       );
        public abstract int                             setObjectiveRelPosition             (int            value       );
        public abstract int                             setObjectiveOperationMode           (int            value       );
        public abstract int                             setObjectiveDRYMode                 (string         value       );
        public abstract int                             setObjectiveMethodParameter         (List<string>   value       );
        public abstract int                             setObjectivePathoMode               (int            value       );
        public abstract int                             setObjectiveDIP                     (                           );
        public abstract (int, int, int, int, int)       getObjectiveStatus                  (                           );
        public abstract (int,           int)            getObjectiveManualOperationStatus   (                           );
        public abstract (int,           int)            getObjectiveAbsPosition             (                           );
        public abstract (int,           int)            getObjectiveOperationStatus         (                           );
        public abstract (int,           int)            getObjectiveDryStatus               (                           );
        public abstract (int,           int)            getObjectiveMethodParameter         (int level, int parameter   );
        public abstract (int,           int)            getObjectiveMinPosition             (                           );
        public abstract (int,           int)            getObjectiveMaxPosition             (                           );
        public abstract (int,           int)            getObjectivePathoMode               (                           ); 
    }
}
