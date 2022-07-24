using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Services
{
    internal class ProductCreator
    {
        private IProductCreator creator;
        public ProductCreator(IProductCreator creator)
        {
            this.creator = creator;
        }
        public IProduct Create()
        {
           return creator.Create();
        }
    }
}
