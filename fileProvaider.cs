using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2048
{
    public class FileProvaider
    {
        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
        public static void Replace(string fileName, string content)
        {
            var writer=new StreamWriter(fileName,false);
            writer.WriteLine(content);
            writer.Close();
        }
    }
}
