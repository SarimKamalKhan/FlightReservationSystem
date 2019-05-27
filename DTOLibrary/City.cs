using System;
using System.Collections.Generic;
using System.Text;

namespace DTOLibrary
{
    abstract class City
    {
        //schema's property here
        public int  Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public string Status { get; set; }

        public City()
        {

        }

    }
}
