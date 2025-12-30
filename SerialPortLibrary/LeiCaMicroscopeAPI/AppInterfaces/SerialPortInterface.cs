using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace AppInterfaces
{
    public interface SerialPortInterface
    {
        SerialPort manager { get; }
        bool hasManager     { get; }
        bool hasParameter   { get; }

        bool IsValid        { get; }

        bool IsAvailable    { get; }

        bool IsOpen         { get; }
        int     Open           ();
        int     Close          ();
        int     ReOpen         ();
        void    initManager    ();
        void    deleManager    ();
        void    initParameter  ();
        void    deleParameter  ();
        void    setParameter(string portname, int baudrate, int databits = 8, int stopbits = 1, int parity = 0);
        string  ReadString  (string frameTail, int timeout = 100);
        byte[]  ReadBinary  (string frameTail, int timeout = 100);
        int     SendString  (string buffer);
        int     SendBinary  (byte[] buffer);
        string  WaitDone    (string buffer, string frameTail, int timeout = 100, int waittime = 50);
        byte[]  WaitDone    (byte[] buffer, string frameTail, int timeout = 100, int waittime = 50);

        
    }
}
