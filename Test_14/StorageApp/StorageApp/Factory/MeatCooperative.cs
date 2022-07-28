using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Cactory
{
    internal class MeatCooperative
    {
        List<IProduct> products;
        public MeatCooperative(IMeatCreator creator)
        {
            products = new();
            products.Add(creator.CreateOtbyvnayua());
            products.Add(creator.CreateFarsh());
            products.Add(creator.CreateOtOsheek());
        }
        public List<IProduct> SendToSuperMarket()
        {
            return products;
        }
    }
}
