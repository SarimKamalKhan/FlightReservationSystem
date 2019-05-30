namespace DataTransferObjects
{
    public class AirlineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string CountryCode { get; set; }
        public AirlineDTO()
        {
            Id = 0;
            Name = string.Empty;
            Code = string.Empty;
            CountryCode = string.Empty;
        }


    }
}
