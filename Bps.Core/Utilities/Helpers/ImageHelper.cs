using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bps.Core.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static Image GetCompanyLogo(string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "images\\company\\";
            List<string> extensions = new List<string> {".png", ".jpg", ".jpeg"};

            foreach (string extension in extensions)
            {
                string file = baseDirectory + fileName + extension;
                if (File.Exists(file)) return Image.FromFile(file);
            }

            return null;
        }
    }
}
