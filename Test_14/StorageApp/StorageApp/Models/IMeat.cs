using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Models
{
    public interface IMeat :Ifood, IWeighable, IUseBefore, ICategory
    {
        public Enums.Kind Kind { get; }
    }
}
