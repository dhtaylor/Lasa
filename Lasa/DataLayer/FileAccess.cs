using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lasa.DataLayer
{
    public class FileAccess
    {
        //* Read operation
        public static string Read(string path, string file)
        {
            string fullFileName = Path.Combine(path, file);
            string output = null;

            if (File.Exists(fullFileName))
            {
                using (StreamReader sr = new StreamReader(fullFileName))
                {
                    output = sr.ReadToEnd();
                }
            }

            return output;
        }

        //* Write operation
        public static void Write(string path, string file, string data)
        {
            string fullFileName = Path.Combine(path, file);

            if (!File.Exists(fullFileName))
            {
                using (StreamWriter sw = new StreamWriter(fullFileName))
                {
                    sw.Write(data);
                }
            }
        }

        //* Append operation
        public static void Append(string path)
        {

        }

        //* Get attribute operation
        public static void GetAttributes(string path)
        {

        }
    }
}
