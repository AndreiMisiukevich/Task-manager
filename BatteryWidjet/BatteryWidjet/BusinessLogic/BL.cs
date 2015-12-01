using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConfiguration;
using System.Diagnostics;

namespace BusinessLogic
{
    public class BL: IBusinessLogic
    {
        public List<Process> RefreshCurrentProcesses()
        {
            var procArr = Process.GetProcesses();
            var procList = new List<Process>();
            for (int i = 0; i < procArr.Length; ++i)
            {
                try
                {
                    if(procArr[i].PriorityClass == ProcessPriorityClass.BelowNormal ||
                       procArr[i].PriorityClass == ProcessPriorityClass.Normal)
                    {
                        procList.Add(procArr[i]);
                    }
                }
                catch
                {
                    continue;
                }
            }

            return procList;
        }
    }
}
