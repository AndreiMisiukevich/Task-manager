using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Applications
{
    public class Application
    {
        private readonly string _name;
        private readonly string _pathApp;
        private readonly string _pathImage;

        public Application(string name, string pathApp, string pathImage = null)
        {
            _name = name;
            _pathApp = pathApp;
            _pathImage = pathImage;
        }

        public override bool Equals(object obj)
        {
            if (obj as Application == null)
                return false;
            return _pathApp == ((Application) obj)._pathApp;
        }

        public override int GetHashCode()
        {
            return _pathApp.GetHashCode() + _pathImage.GetHashCode();
        }

        public override string ToString()
        {
            return _name;
        }

        public string PathApplication { get { return _pathApp; } }
        public string PathImage { get { return _pathImage; } }

    }
}
