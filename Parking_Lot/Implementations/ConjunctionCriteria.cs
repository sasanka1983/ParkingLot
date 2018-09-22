using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_Lot.BusinessObjects;
using Parking_Lot.Interfaces;

namespace Parking_Lot.Implementations
{
    public class ConjunctionCriteria<T>:IParkingSlotCriteria<T>
    {
        private IParkingSlotCriteria<T> _first;
        private IParkingSlotCriteria<T> _second;

        public ConjunctionCriteria(IParkingSlotCriteria<T> first, IParkingSlotCriteria<T> second)
        {
            _first = first;
            _second = second;
        }

        public bool IsCriteriaMet(T t)
        {
            return _first.IsCriteriaMet(t) && _second.IsCriteriaMet(t);
        }
    }
}
