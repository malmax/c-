using System;
using System.Timers;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            ElapsedEventHandler del = new ElapsedEventHandler(Timer_Elapsed);
            del += Timer_Elapsed2;
            del -= Timer_Elapsed2;
            timer.Elapsed += del;
            timer.Elapsed += del;
            timer.Elapsed -= del;
            //timer.Start();
            timer.Enabled = true;
            //if (timer.Enabled)
            Console.ReadKey();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("1."+e.SignalTime);
        }

        private static void Timer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("2."+e.SignalTime);
        }
    }
}
