namespace DTOLibrary
{
    public class City
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Status { get; set; }
        public City()
        {
            Id = 0;
            Name = string.Empty;
            CountryCode = string.Empty;
            Status = "0";
        }

    }
}
