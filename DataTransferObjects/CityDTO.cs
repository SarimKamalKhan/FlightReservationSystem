namespace DataTransferObjects
{
    public class CityDTO
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CityCode { get; set; }

        public CityDTO()
        {
            Id = 0;
            Name = string.Empty;
            CountryCode = string.Empty;
            CityCode = string.Empty;

        }

    }
}
