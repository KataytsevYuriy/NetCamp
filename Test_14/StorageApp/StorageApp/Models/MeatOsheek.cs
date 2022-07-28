using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Models
{
    internal class MeatOsheek : Meat
    {
        public MeatOsheek(string name, double price, double weight, DateTime useBefore, Enums.Kind kind, Enums.Category category, int count = 1)
            : base(name, price, weight, useBefore, kind, category)
        { }
    }
}
