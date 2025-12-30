using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using AppUtils;
using AppInterfaces;

namespace SerialPortAPI
{
    public class SerialPortReader: AbstractSerialPortInterface
    {
        
        public SerialPortReader(string portname = "COM1" , int baudrate = 9600)
        {
            initialization("SerialPortReader");
            setParameter(portname, baudrate);
        }
        ~SerialPortReader()
        {
            deinitialize();
        }
        public override void initValue()
        {
            initParameter   ();
            initManager     ();
        }
        public override void deleValue()
        {
            deleManager     ();
            deleParameter   ();
        }
        public override SerialPortInterface Instance() { return new SerialPortReader(); }
        
        
    }
}
