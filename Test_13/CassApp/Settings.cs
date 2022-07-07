using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal class Settings
    {
        public const string PersonsFileName = @"..\..\..\Files/Person.txt";
        public const string ResultFileName = @"..\..\..\Files/Result.txt";
        public const int PersonTimeToIn = 2;
        public const int MaxCoordinate = 20;
        public const int ReadLinesCount = 20;
        public static Dictionary<int, string> Status = new()
        {
            { 0, "user" },
            { 1, "student" },
            { 2, "warior"},
            { 3, "pensioner"},
        };
    }
}
