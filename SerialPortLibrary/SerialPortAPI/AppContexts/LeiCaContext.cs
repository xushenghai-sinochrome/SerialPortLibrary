using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppInterfaces
{
    public class LeiCaContext : ContextInterface
    {
        public LeiCaContext(string portname = "COM5", int baudrate = 9600)
        {
            initialization("徕卡显微镜上下文");
            PortName = portname;
            BaudRate = baudrate;
        }
        public override void initValue()
        {
            PortName    = "COM6"    ;
            BaudRate    = 9600      ;
            DataBits    = 8         ;
            StopBits    = 1         ;
            Parity      = 0         ;
            ReadTimeout = 100       ;
            SendTimeout = 1000      ;
        }
        public string   PortName    { get; set; }
        public int      BaudRate    { get; set; }
        public int      DataBits    { get; set; }
        public int      StopBits    { get; set; }
        public int      Parity      { get; set; }
        public int      ReadTimeout { get; set; }
        public int      SendTimeout { get; set; }

    }
}
