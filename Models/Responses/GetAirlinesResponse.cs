using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class GetAirlinesResponse
    {
        public IList<AirlineDTO> AirLines { get; set; }

        public GetAirlinesResponse()
        {
            AirLines = new List<AirlineDTO>();
        }
    }
}
