using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Models
{
    public interface IManufactured : IProduct
    {
        public DateTime Manufactured { get; }
    }
}
