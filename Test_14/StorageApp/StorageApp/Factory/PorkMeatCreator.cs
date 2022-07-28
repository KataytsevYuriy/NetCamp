using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Cactory
{
    internal class PorkMeatCreator:IMeatCreator
    {
        public IMeat CreateFarsh()
        {
            return new MeatFarsh("Pork farsh", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.pork, Enums.Category.firstSort);
        }

        public IMeat CreateOtbyvnayua()
        {
            return new MeatOtbyvnayu("Pork otbyvnayua", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.pork, Enums.Category.firstSort);
        }

        public IMeat CreateOtOsheek()
        {
            return new MeatOsheek("Pork osheek", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.pork, Enums.Category.firstSort);
        }
    }
}
