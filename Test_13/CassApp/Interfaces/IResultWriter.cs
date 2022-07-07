using CassApp;
using System.Collections.Generic;

namespace Task12_3
{
    internal interface IResultWriter
    {
        void WritePerson(List<string> calculateExpressions,
            string filePath =Settings.ResultFileName);
    }
}
