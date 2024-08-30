using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace ConsoleTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var task = Task.Run(() => { 
            //        var numberOfCharacters = File.ReadAllText(@"C:\Users\Niki\source\repos\ConsoleTasks\Текстовый документ.txt").
            //        Count(x => x == ' ');
            //    Console.WriteLine(numberOfCharacters);
            //});

            //var task2 = Task.Run(() => {
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.WriteLine($"{j} (2)");
            //        Thread.Sleep(1000);
            //    }
            //});

            //task.Wait();
            //task2.Wait();
            //Console.WriteLine("Готово!");
            //Console.ReadLine();

            //задание 1

            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            string elapsedTime;

            stopWatch.Start();
            var files = new[] { @"C:\Users\Niki\source\repos\ConsoleTasks\Текстовый документ.txt", @"C:\Users\Niki\source\repos\ConsoleTasks\Текстовый документ — копия.txt" };
            var tasks = files.Select(file => Task.Run(() => searchCharInFile(file, ' ')));
            Console.WriteLine(tasks.Sum(task => task.Result));
            stopWatch.Stop();

            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            

            //задание 2

            stopWatch.Start();
            var tasks2 = readFolder(@"C:\Users\Niki\source\repos\ConsoleTasks\","*.txt").Select(file => Task.Run(() => searchCharInFile(file, ' ')));
            Console.WriteLine(tasks2.Sum(task => task.Result));
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
        }

        static async Task<int> searchCharInFile(string file, char c)
        {
            int count = File.ReadAllText(file).//@"C:\Users\Niki\source\repos\ConsoleTasks\Текстовый документ.txt").
                    Count(x => x == c);
            return count;
        }

        static string[] readFolder(string folder, string ext)
        {
            return Directory.GetFiles(folder, ext);
        }
    }
}
