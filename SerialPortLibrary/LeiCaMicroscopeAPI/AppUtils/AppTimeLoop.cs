using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppUtils
{
    public class AppTimeLoop
    {
        public static void ProcessEvents(int interVal)
        {
            int waittime            = 2;
            int TotalMilliseconds   = 0;
            DateTime startTime = DateTime.Now;
            while(true)
            {
                Thread.Sleep(waittime);
                TotalMilliseconds = Math.Abs((int)(DateTime.Now - startTime).TotalMilliseconds);
                if (TotalMilliseconds >= interVal)
                    break;
            }
        }
        public static void delay(int interVal)
        {
            if (interVal == 0)
                return;
            Thread.Sleep(Math.Abs(interVal));
        }
        public static void msleep(int interVal)
        {
            if (interVal == 0)
                return;
            Thread.Sleep(Math.Abs(interVal));
        }
        public static void sleep(int interVal)
        {
            if (interVal == 0)
                return;
            Thread.Sleep(Math.Abs(interVal * 1000));
        }
    }
}
