using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Services
{
    internal static class FileService
    {
        public static List<string> Load(string filaName)
        {
            List<string> result = new List<string>();
            using (StreamReader stream = new StreamReader(filaName))
            {
                while (!stream.EndOfStream)
                {
                    result.Add(stream.ReadLine() ?? "");
                }
            }
            return result;
        }
        public static List<string> Load(string filaName, int partNumber)
        {
            List<string> result = new List<string>();
            result = File.ReadLines(filaName).Skip(Settings.ReadLinesCount * (partNumber))
                .Take(Settings.ReadLinesCount).ToList();
            //using (StreamReader stream = new StreamReader(filaName))
            //{
            //    while (!stream.EndOfStream)
            //    {
            //        result.Add(stream.ReadLine() ?? "");
            //    }
            //}
            return result;
        }
        public static void Save(string fileName, List<string> data, bool appendData = true)
        {
            using (StreamWriter stream = new StreamWriter(fileName, appendData))
            {
                foreach (string line in data)
                {
                    stream.WriteLine(line);
                }
            }
        }
        public static void Save(string fileName, string data, bool appendData = true)
        {
            Save(fileName, new List<string> { data }, appendData);
        }
    }
}
