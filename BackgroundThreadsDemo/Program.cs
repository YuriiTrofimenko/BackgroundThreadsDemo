using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundThreadsDemo
{
    class Program
    {
        private static volatile bool isAlive;
        private static volatile bool isPaused;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                /* while (true)
                {
                    Console.WriteLine("Hello!");
                    //Thread.Sleep(10);
                } */
                for (int i = 0; i < 30; i++)
                {
                    if (isAlive)
                    {
                        if (isPaused)
                        {
                            Thread.CurrentThread.Suspend();
                        }
                        Console.Write($"{i} Start-");
                        Console.Write($"{i} Work-");
                        Console.WriteLine($"{i} Finish");
                        Thread.Sleep(new Random().Next(1, 11));
                    }
                    else {
                        Thread.CurrentThread.Interrupt();
                    }
                }
            });
            t1.Name = "BackgroundThreadsDemo-1";
            //t1.IsBackground = true;

            isAlive = true;
            t1.Start();

            isPaused = false;
            // t1.Join(100);
            Thread.Sleep(100);

            isPaused = true;

            Thread.Sleep(5000);

            isPaused = false;
            t1.Resume();

            // isAlive = false;

            // t1.Interrupt();

            Console.WriteLine("End");
        }
    }
}
