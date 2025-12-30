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
    public class LMicroscopeReader: AbstractLMicroscope
    {
        /*=====================================================================================================================*/
        public override int                             setMasterEvents                     (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_EVENT, 0, 0, 0, 0, 0, 0, 0, 0 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriveEvents                     (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVE_EVENT, 1, 1, 1, 1, 1, 1, 0, 0 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVE_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveEvents                  (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_EVENT, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setTLFieldEvents                    (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_FIELD_TL_EVENT, 1, 1 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_FIELD_TL_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setTLEvents                         (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_TL_EVENT, 1, 1 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_TL_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setSpotLightEvents                  (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_SPOTLIGHT_EVENT, 1 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_SPOTLIGHT_EVENT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setMasterReset                      (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_RESET};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_RESET);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setMasterDefault                    (                           ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_DEFAULT};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_DEFAULT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setMasterConfigMode                 (bool enable                ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_CONFIG_MODE, enable ? 1 : 0};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_CONFIG_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setMasterWaitTimes                  (int  waittimes             ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_WAIT_TIMES, waittimes <= 0 ? 0 : waittimes};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_WAIT_TIMES);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setManualOptionStatus               (bool enable                ) {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_MASTER_MANUAL_OPERATION, enable ? 1 : 0};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_MASTER_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override (int, int)                      getMicroscopeInitStatus             (                           ) {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_MASTER_MANUAL_OPERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_MASTER_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int, int)                      getMasterFirmwareStatus             (                           ) {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_MASTER_FIRMWARE_STATUS};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_MASTER_FIRMWARE_STATUS);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int, int)                      getMasterConfigMode                 (                           ) {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_MASTER_FIRMWARE_STATUS};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_MASTER_FIRMWARE_STATUS);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int, int)                      getManualOptionStatus               (                           ) {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_MASTER_MANUAL_OPERATION};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_MASTER_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }

        /*=====================================================================================================================*/
        public override int                             setZDriverManualOptionStatus        (bool enable                )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_MANUAL_OPERATION, enable ? 1 : 0 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverReset                     (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_RESET};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_RESET);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverInit                      (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_INIT};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_INIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverBreak                     (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_BREAK};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_BREAK);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverAbsPosition               (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_ABS_POSITION, value <= 0 ? 0 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_ABS_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverRelPosition               (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_REL_POSITION, value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_REL_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverConstPosition             (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_CONST_POSITION, value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_CONST_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverLowerLimit                (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_LOWER_LIMIT, value < 0 ? -1 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_LOWER_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverFocusLimit                (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_FOCUS_LIMIT, value <= 0 ? 0 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_FOCUS_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverUpperLimit                (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_UPPER_LIMIT, value <= 0 ? -1 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_UPPER_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverAcceleration              (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_ACCELERATION, value <= 1 ? 1 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_ACCELERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverSpeed                     (int value                  )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_SPEED, value <= 1 ? 1 : value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_SPEED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             ZDriverMoveToFocusLimit             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.Z_DRIVER_MOVE_TO_FOCUS_LIMIT};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.Z_DRIVER_MOVE_TO_FOCUS_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             ZDriverMoveToLowerLimit             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.Z_DRIVER_MOVE_TO_LOWER_LIMIT};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.Z_DRIVER_MOVE_TO_LOWER_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             ZDriverPositionAsFocus              (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_FOCUS_POSITION};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_FOCUS_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             ZDriverPositionAsLower              (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_LOWER_POSITION};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_LOWER_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             ZDriverInitRange                    (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.Z_DRIVER_INIT_RANGE};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.Z_DRIVER_INIT_RANGE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverMoveMode                  (bool enable                )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_MOVE_MODE, enable ? 1 : 0};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_MOVE_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverFocusLimitEnable          (bool enable                )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_FOCUS_LIMIT_ENABLED, enable ? 1 : 0};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_FOCUS_LIMIT_ENABLED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setZDriverInitMode                  (string value               )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_Z_DRIVER_INIT_MODE};
                string MicParameterTails = $" {value}{MicSettings.MicParameterTails}";
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_Z_DRIVER_INIT_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override (int, int, int, int, int, int)       getZDriverStatus                    (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Moving    = Settings.DEFAULT_RESULT_INT ;
            int Lower     = Settings.DEFAULT_RESULT_INT ;
            int Upper     = Settings.DEFAULT_RESULT_INT ;
            int LowLimit  = Settings.DEFAULT_RESULT_INT ;
            int Focus     = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_STATUS };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_STATUS);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                            {
                                Moving    = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]) ;
                                Lower     = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 2]) ;
                                Upper     = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 3]) ;
                                LowLimit  = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 4]) ;
                                Focus     = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 5]);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Moving, Lower, Upper, LowLimit, Focus);
        }
        public override (int,           int     )       getZDriverManualOptionStatus        (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MANUAL_OPERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverFirmwareStatus            (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_FIRMWARE_STATUS };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_FIRMWARE_STATUS);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverAbsPosition               (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_ABS_POSITION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_ABS_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverLowerLimit                (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_LOWER_LIMIT };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_LOWER_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverFocusLimit                (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_FOCUS_LIMIT };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_FOCUS_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverAcceleration              (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_ACCELERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_ACCELERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverSpeed                     (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_SPEED };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_SPEED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverConvertFactor             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_CONVERT_FACTOR };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_CONVERT_FACTOR);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int, int) getZDriverMinAcceleration()
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MIN_ACCELERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MIN_ACCELERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverMaxAcceleration           (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MAX_ACCELERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MAX_ACCELERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverMoveMode                  (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MOVE_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MOVE_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverFocusLimitEnable          (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_FOCUS_LIMIT_ENABLED };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_FOCUS_LIMIT_ENABLED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverMinSpeed                  (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MIN_SPEED };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MIN_SPEED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverMaxSpeed                  (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_MAX_SPEED };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_MAX_SPEED);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int     )       getZDriverUpperLimit                (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_UPPER_LIMIT };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_UPPER_LIMIT);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           string  )       getZDriverInitMode                  (                           )
        {
            int     isWarning = Settings.RECODE_FAILURE     ;
            string  Result    = Settings.DEFAULT_RESULT_STR ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_Z_DRIVER_INIT_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        string[] ResultBuffer = MicroscopeUtil.ConvertStringList(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Length >= 1)
                        {
                            int index = MicroscopeUtil.StringListIndexOf(ResultBuffer, MicControllerID.GET_Z_DRIVER_INIT_MODE.ToString());// ResultBuffer.IndexOf(MicControllerID.GET_Z_DRIVER_INIT_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = ResultBuffer[index + 1];
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        /*===============================================物镜操作方法======================================================================*/
        public override int                             setObjectiveManualOperation         (bool           value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_MANUAL_OPERATION, value ? 1 : 0};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveAbsPosition             (int            value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_ABS_POSITION, value >= 1 && value <= 7 ? value : 1 };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_ABS_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveRelPosition             (int            value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_REL_POSITION , value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_REL_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveOperationMode           (int            value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_OPERATION_MODE , value};
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_OPERATION_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveDRYMode                 (string         value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_DRY_MODE };
                string MicParameterTails = $" {value}{MicSettings.MicParameterTails}";
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_DRY_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveMethodParameter         (List<string>   value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_METHOD_PARAMETER };
                string MicParameterTails = " " + string.Join(",", value) + MicSettings.MicParameterTails;
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_METHOD_PARAMETER);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectivePathoMode               (int            value       )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_PATHO_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_PATHO_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override int                             setObjectiveDIP                     (                           )
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.SET_OBJECTIVE_DIP };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.SET_OBJECTIVE_DIP);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return isWarning;
        }
        public override (int, int, int, int, int)       getObjectiveStatus                  (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Status1   = Settings.DEFAULT_RESULT_INT ;
            int Status2   = Settings.DEFAULT_RESULT_INT ;
            int Status3   = Settings.DEFAULT_RESULT_INT ;
            int Status4   = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_STATUS };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_STATUS);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                            {
                                Status1   = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                                Status2   = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                                Status3   = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                                Status4   = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Status1, Status2, Status3, Status4);
        }
        public override (int,           int)            getObjectiveManualOperationStatus   (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_MANUAL_OPERATION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_MANUAL_OPERATION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveAbsPosition             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_ABS_POSITION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_ABS_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveOperationStatus         (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_OPERATION_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_OPERATION_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveDryStatus               (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_DRY_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_DRY_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveMethodParameter         (int level, int parameter   )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_METHOD_PARAMETER };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_METHOD_PARAMETER);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveMinPosition             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_MIN_POSITION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_MIN_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectiveMaxPosition             (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_MAX_POSITION };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_MAX_POSITION);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public override (int,           int)            getObjectivePathoMode               (                           )
        {
            int isWarning = Settings.RECODE_FAILURE     ;
            int Result    = Settings.DEFAULT_RESULT_INT ;
            try
            {
                List<int> Parameters = new List<int>() { MicControllerID.GET_OBJECTIVE_PATHO_MODE };
                string SendBuffer = MicroscopeUtil.ConvertToString(Parameters, MicSettings.MicParameterSpace, MicSettings.MicParameterTails);
                if (!String.IsNullOrEmpty(SendBuffer))
                {
                    string ReadBuffer = WaitDone(SendBuffer, MicSettings.MicParameterTails, MicSettings.MicMaxFrameTimeOut, MicSettings.MicFrameSpaceTime);
                    if (!String.IsNullOrEmpty(ReadBuffer))
                    {
                        List<int> ResultBuffer = MicroscopeUtil.Parser(ReadBuffer, MicSettings.MicParameterTails);
                        if (ResultBuffer.Count >= 1)
                        {
                            int index = ResultBuffer.IndexOf(MicControllerID.GET_OBJECTIVE_PATHO_MODE);
                            isWarning = index >= 0 ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
                            if (Settings.RECODE_SUCCEED == isWarning)
                                Result = MicroscopeUtil.ConvertToInt(ResultBuffer[index + 1]);
                        }
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine($"{Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(e.Message))}"); }
            return (isWarning, Result);
        }
        public LMicroscopeReader(string PortName = "COM6", int baudrate = 9600)
        {
            initialization("LMicroscopeReader");
            setParameter(PortName, baudrate);
        }
        ~LMicroscopeReader()
        {
            deinitialize();
        }
        public override void initValue()
        {
            initParameter();
            initManager();
        }
        public override void deleValue()
        {
            deleManager();
            deleParameter();
        }
        public override ILMicroscopeInterface Instance() { return new LMicroscopeReader(); }
    }
}
