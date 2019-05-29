using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccess.Repositories.City
{
    interface ICityRepository
    {
        IList<CityDTO> GetByCountryCode (string countryCode,out string response);
    }
}
