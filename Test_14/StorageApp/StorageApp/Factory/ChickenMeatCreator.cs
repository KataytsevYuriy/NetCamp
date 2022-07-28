using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Cactory
{
    internal class ChickenMeatCreator : IMeatCreator
    {
        public IMeat CreateFarsh()
        {
            return new MeatFarsh("Chicken farsh", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.chicken, Enums.Category.firstSort);
        }

        public IMeat CreateOtbyvnayua()
        {
            return new MeatOtbyvnayu("Chicken otbyvnayua", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.chicken, Enums.Category.firstSort);
        }

        public IMeat CreateOtOsheek()
        {
            return new MeatOsheek("Chicken osheek", 56, 1, DateTime.Now.AddDays(10), Enums.Kind.chicken, Enums.Category.firstSort);
        }
    }
}
