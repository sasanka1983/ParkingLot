using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.Interfaces
{
    public interface IParkingLotFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, IParkingSlotCriteria<T> t);
    }
}
