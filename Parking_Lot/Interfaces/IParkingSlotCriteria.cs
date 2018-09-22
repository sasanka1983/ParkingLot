using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.Interfaces
{
    public interface IParkingSlotCriteria<T>
    {
        bool IsCriteriaMet(T t);
    }
}
