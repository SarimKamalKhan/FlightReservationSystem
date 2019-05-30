using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.Responses
{
    public class GetCitiesResponse
    {
        public IList<CityDTO> Cities { get; set; }

        public GetCitiesResponse()
        {
            Cities = new List<CityDTO>();
        }
    }
}
