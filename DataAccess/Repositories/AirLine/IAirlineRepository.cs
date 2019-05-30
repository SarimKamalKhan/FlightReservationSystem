using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AirLine
{
    interface IAirlineRepository
    {
        IList<AirlineDTO> GetByCountryCode(string countryCode, out string response);
    }
}
