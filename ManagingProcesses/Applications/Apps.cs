using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications
{
    public static class Apps
    {
        public static readonly Application AIMP3 = new Application("AIMP3", 
            @"C:\Program Files (x86)\AIMP3\AIMP3.exe",
            null);

        public static readonly Application Chrome = new Application("Google Chrome",
            @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
            null);

        public static readonly Application SublimeText = new Application("Sublime Text 3",
            @"C:\Program Files\Sublime Text 3\sublime_text.exe",
            null);
    }
}
