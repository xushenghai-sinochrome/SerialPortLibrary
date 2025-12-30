using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppInterfaces
{
    public class SerialPortController
    {
        private static readonly object IOLocker = new object();
        public static int     Open              (SerialPortInterface manager){
            try
            {
                return manager.Open();
            }
            catch (Exception) { }
            return 0;
        }
        public static int     Close             (SerialPortInterface manager){
            try
            {
                return manager.Close();
            }
            catch (Exception) { }
            return 0;
        }
        public static int     ReOpen            (SerialPortInterface manager)
        {
            try
            {
                return manager.ReOpen();
            }
            catch (Exception) { }
            return 0;
        }
        public static string  ReadString        (SerialPortInterface manager, string frameTail, int timeout = 100)
        {
            try
            {
                return manager.ReadString(frameTail, timeout);
            }
            catch (Exception) { }
            return default(string);
        }
        public static byte[]  ReadBinary        (SerialPortInterface manager, string frameTail, int timeout = 100)
        {
            try
            {
                return manager.ReadBinary(frameTail, timeout);
            }
            catch (Exception) { }
            return default(byte[]);
        }
        public static int     SendString        (SerialPortInterface manager, string buffer)
        {
            try
            {
                return manager.SendString(buffer);
            }
            catch (Exception) { }
            return default(int);
        }
        public static int     SendBinary        (SerialPortInterface manager, byte[] buffer)
        {
            try
            {
                return manager.SendBinary(buffer);
            }
            catch (Exception) { }
            return default(int);
        }
        public static string  WaitDone          (SerialPortInterface manager, string buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            lock(IOLocker)
            {
                try
                {
                    return manager.WaitDone(buffer, frameTail, timeout, waittime);
                }
                catch (Exception) { }
            }
            return default(string);
        }
        public static byte[]  WaitDone          (SerialPortInterface manager, byte[] buffer, string frameTail, int timeout = 100, int waittime = 50)
        {
            lock (IOLocker)
            {
                try
                {
                    return manager.WaitDone(buffer, frameTail, timeout, waittime);
                }
                catch (Exception) { }
            }
            return default(byte[]);
        }

    }
}
