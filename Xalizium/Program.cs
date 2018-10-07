using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xalizium
{
    public class Program
    {
        private static Thread TimerThread;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // GONNA CATCH THEM ALL

            TimerThread = new Thread(() =>
             {
                // Stopwatch for the lols
                Stopwatch sw = new Stopwatch();
                 sw.Start();

                 while (sw.IsRunning)
                 {
                     Console.Title = sw.Elapsed.ToString("hh':'mm':'ss");
                     Thread.Sleep(100);
                 }
             });
            TimerThread.Start();

            using (Game game = new Game())
            {
                game.Run();
            }  
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            TimerThread?.Abort();

            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("If You See This Error Message, Contact The Idiot Who Programmed The Game And Tell Him To Fix His SHIT!\n");
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("\nPress Enter to Exit!");

            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
