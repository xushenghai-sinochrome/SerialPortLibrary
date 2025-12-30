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
    public class ScanCodeReader: AbstractScanCodeInterface
    {
        public ScanCodeReader(string portname = "COM5", int baudrate = 9600)
        {
            initialization("ScanCodeReader");
            setParameter(portname, baudrate);
        }
        ~ScanCodeReader()
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
        public override ScanCodeInterface Instance() { return new ScanCodeReader(); }

    }
}
