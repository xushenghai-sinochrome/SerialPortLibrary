using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace AppUtils
{
    using AppInterfaces;
    public class SerialPortUtil
    {
        public static int Open(SerialPort Manager, SerialContext Parameter)
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                if (Manager == null || Parameter == null)
                    return isWarning;
                if (Manager.IsOpen)
                    SerialPortUtil.Close(Manager);
                Manager.PortName        =           Parameter.PortName              ;
                Manager.BaudRate        =           Parameter.BaudRate              ;
                Manager.DataBits        =           Parameter.DataBits              ;
                Manager.StopBits        = (StopBits)Parameter.StopBits              ;
                Manager.Parity          = (Parity)  Parameter.Parity                ;
                Manager.ReadTimeout     =           Parameter.ReadTimeout           ;
                Manager.WriteTimeout    =           Parameter.SendTimeout           ;
                Manager.Open            (                              );
                isWarning = Manager.IsOpen ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
            }
            catch (Exception) { }
            return isWarning;
        }
        public static int Open(SerialPort Manager, LeiCaContext Parameter)
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                if (Manager == null || Parameter == null)
                    return isWarning;
                if (Manager.IsOpen)
                    SerialPortUtil.Close(Manager);
                Manager.PortName        =           Parameter.PortName              ;
                Manager.BaudRate        =           Parameter.BaudRate              ;
                Manager.DataBits        =           Parameter.DataBits              ;
                Manager.StopBits        = (StopBits)Parameter.StopBits              ;
                Manager.Parity          = (Parity)  Parameter.Parity                ;
                Manager.ReadTimeout     =           Parameter.ReadTimeout           ;
                Manager.WriteTimeout    =           Parameter.SendTimeout           ;
                Manager.Open            (                              );
                isWarning = Manager.IsOpen ? Settings.RECODE_SUCCEED : Settings.RECODE_FAILURE;
            }
            catch (Exception) { }
            return isWarning;
        }

        public static int Close(SerialPort Manager)
        {
            int isWarning = Settings.RECODE_SUCCEED;
            try
            {
                if (Manager == null)
                    return isWarning;
                if (Manager.IsOpen)
                {
                    Manager.Close();
                }
            }
            catch (Exception) { }
            return isWarning;
        }

        public static int SendString(SerialPort Manager, string buffer)
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                if (Manager == null)
                    return isWarning;
                if (buffer.Length == 0)
                    return isWarning;
                Manager.Write(buffer);
                isWarning = Settings.RECODE_SUCCEED;
            }
            catch (Exception) { }
            return isWarning;
        }
        public static int SendBinary(SerialPort Manager, byte[] buffer)
        {
            int isWarning = Settings.RECODE_FAILURE;
            try
            {
                if (Manager == null)
                    return isWarning;
                if (buffer.Length == 0)
                    return isWarning;
                Manager.Write(buffer, 0, buffer.Length);
                isWarning = Settings.RECODE_SUCCEED;
            }
            catch (Exception) { }
            return isWarning;
        }

        public static string ReadString(SerialPort Manager, string frameTail = null, int timeout=1000)
        {
            StringBuilder Buffer = new StringBuilder();
            try
            {
                if (Manager == null)
                    return Buffer.ToString();
                int waittimes = 10;
                DateTime    starttime   = DateTime.Now  ;
                int         readLength  = 0             ;
                int         timeOffset                  ;
                bool IsTail = (frameTail != null) && (frameTail.Length > 0);
                bool atEnd = false;
                while (true)
                {
                    readLength = Manager.BytesToRead;
                    if (readLength > 0)
                    {
                        Buffer.Append(Manager.ReadExisting());
                    }
                    if (IsTail)
                        atEnd = Buffer.ToString().IndexOf(frameTail, 0) >= 0;
                    else
                        atEnd = Buffer.Length > 0;
                    if (atEnd)
                        break;
                    timeOffset = (int)(DateTime.Now - starttime).TotalMilliseconds;
                    if (Math.Abs(timeOffset) >= timeout)
                        break;
                    AppTimeLoop.ProcessEvents(waittimes);
                }
            }
            catch (Exception) { }
            return Buffer.ToString();
        }
        public static byte[] ReadBinary(SerialPort Manager, string frameTail = null, int timeout = 1000)
        {
            List<byte> Buffer = new List<byte>();
            try
            {
                if (Manager == null)
                    return Buffer.ToArray();
                
                int         waittimes   = 10            ;
                DateTime    starttime   = DateTime.Now  ;
                int         readLength  = 0             ;
                int         timeOffset                  ;
                bool IsTail = (frameTail != null) && (frameTail.Length > 0);
                byte[] tailByteArray = IsTail ? Encoding.UTF8.GetBytes(frameTail) : null;
                bool atEnd = false;
                long index = -1;
                while (true)
                {
                    readLength = Manager.BytesToRead;
                    if (readLength > 0)
                    {
                        byte[] readbuffer = new byte[readLength];
                        int received_length = Manager.Read(readbuffer, 0, readbuffer.Length);
                        if(received_length > 0)
                            Buffer.AddRange(readbuffer);
                    }
                    if (IsTail)
                    {
                        try
                        {
                            index = IndexesOf(Buffer.ToArray(), 0, tailByteArray).First<long>();
                        }
                        catch (Exception) { 
                            index = -1; 
                        }
                        atEnd = index >= 0;
                    }
                        
                    else
                        atEnd = Buffer.ToArray().Length > 0;
                    if (atEnd)
                        break;
                    timeOffset = (int)(DateTime.Now - starttime).TotalMilliseconds;
                    if (Math.Abs(timeOffset) >= timeout)
                        break;
                    AppTimeLoop.ProcessEvents(waittimes);
                }
            }
            catch (Exception) { }
            return Buffer.ToArray();
        }

        public static IEnumerable<long> IndexesOf(byte[] source, int start, byte[] pattern)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            long valueLength = source.LongLength;
            long patternLength = pattern.LongLength;

            if ((valueLength == 0) || (patternLength == 0) || (patternLength > valueLength))
            {
                yield break;
            }

            var badCharacters = new long[256];

            for (var i = 0; i < 256; i++)
            {
                badCharacters[i] = patternLength;
            }

            var lastPatternByte = patternLength - 1;

            for (long i = 0; i < lastPatternByte; i++)
            {
                badCharacters[pattern[i]] = lastPatternByte - i;
            }

            long index = start;

            while (index <= valueLength - patternLength)
            {
                for (var i = lastPatternByte; source[index + i] == pattern[i]; i--)
                {
                    if (i == 0)
                    {
                        yield return index;
                        break;
                    }
                }

                index += badCharacters[source[index + lastPatternByte]];
            }
        }
    }
}
