using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Models
{
    public interface IProduct
    {
        public string Id { get; }
        public string Name { get; }
        public double Price { get; }
        public int Count { get; }

    }
}
