using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface ScanCodeInterface: SerialPortInterface
    {
        ScanCodeInterface Instance();
        string  ScanCode        (int timeout = 1000, int waittime = 50  );
        void    StopScanCode    (int timeout = 1000, int waittime = 50  );
        string  SetHostMode     (int timeout = 1000, int waittime = 50  );
        string  GetVersion      (int timeout = 1000, int waittime = 50  );
        void    ClearBuffer     (                                       );
    }
}
