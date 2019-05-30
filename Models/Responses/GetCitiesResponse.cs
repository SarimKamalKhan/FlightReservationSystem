using DataTransferObjects;
using System.Collections.Generic;

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
