using StorageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp.Cactory
{
    internal interface IMeatCreator
    {
        IMeat CreateFarsh();
        IMeat CreateOtbyvnayua();
        IMeat CreateOtOsheek();
    }
}
