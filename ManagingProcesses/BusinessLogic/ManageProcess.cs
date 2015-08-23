using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ManageProcess
    {
        public ManageProcess()
        {
        }

        public List<Process> GetProcesses()
        {
            return Process.GetProcesses().ToList();
        }

        public List<string> GetProcessNames()
        {
            return Process.GetProcesses().ToList().Select((x) => x.ProcessName).ToList();
        }

        public bool RemoveById(int id)
        {
            var process = Process.GetProcessById(id);
            try
            {
                process.Kill();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveByName(string name)
        {
            try
            {
                var processes = Process.GetProcessesByName(name);
                processes.ToList().ForEach(x => x.Kill());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddApplication(string path)
        {
            try
            {
                Process.Start(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
