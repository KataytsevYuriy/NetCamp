using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Services
{
    internal interface IProductCreator
    {
        IProduct Create();
    }
}
