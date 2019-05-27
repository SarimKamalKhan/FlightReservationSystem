using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary
{
    abstract class TravelCategory
    {
        //public abstract string Get_TravelClass();

        public abstract int Id { get; set; }

        public abstract string Type { get; set; }
        public abstract string Name { get; set; }
        public abstract string PricePerSeat { get; set; }

        public abstract string Code { get; set; }
    }
}
