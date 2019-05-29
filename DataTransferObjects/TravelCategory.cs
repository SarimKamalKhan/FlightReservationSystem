using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects
{
    abstract class TravelCategory
    {
        public abstract int Id { get; set; }
        public abstract string Type { get; set; }
        public abstract string Name { get; set; }
        public abstract string PricePerSeat { get; set; }
        public abstract string Code { get; set; }
    }
}
