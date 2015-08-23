using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DEMOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mp = new ManageProcess();
            foreach (var processName in mp.GetProcesses())
            {
                try
                {
                    Console.WriteLine(processName.Handle + " Handle");
                    Console.WriteLine(processName.Id + " Id");
                    Console.WriteLine(processName.ProcessName + " ProcessName");
                    Console.WriteLine(processName.ProcessorAffinity + " ProcessorAffinity");
                    Console.WriteLine(processName.StartInfo + " StartInfo");
                    Console.WriteLine(processName.StartTime + " StartTime");
                    for (int i = 0; i < processName.Threads.Count; i++)
                    {
                        Console.WriteLine(processName.Threads[i].StartTime + " threed!! " + i);
                    }
                    Console.WriteLine(processName.UserProcessorTime + " UserProcessorTime");
                    Console.WriteLine(processName.VirtualMemorySize64 + " VirtualMemorySize64");
                    Console.WriteLine(processName.WorkingSet64 + " WorkingSet64");
                    Console.WriteLine(processName.PriorityBoostEnabled + " PriorityBoostEnabled");
                    Console.WriteLine(processName.PriorityClass + " PriorityClass");
                }
                catch (Exception e)
                {
                    Console.WriteLine("exception!!!!!!!!!!!!!!!!!!" + e.Data + e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
