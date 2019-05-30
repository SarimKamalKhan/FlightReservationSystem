using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.Responses
{
    public class GetCitiesResponse
    {
        public List<CityDTO> Cities { get; set; }

        public GetCitiesResponse()
        {
            Cities = new List<CityDTO>();
        }
    }
}
