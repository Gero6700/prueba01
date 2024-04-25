namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Hotel : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime? OpeningDate { get; set; }
    public DateTime? ClosingDate { get; set; }
    public string Category { get; set; } = string.Empty;
    public string CodeType { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int NumberOfRooms { get; set; }
    public int Floors { get; set; }
    public int BuildYear { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    //Address
    public string Country { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string StateProvince { get; set; } = string.Empty;
    public string StateProvinceCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string CityCode { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
    //Contact
    public string Phone { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string ReferencePerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Web { get; set; } = string.Empty;
    //Pax age configuration
    public decimal ChildMinAge { get; set; }
    public decimal ChildMaxAge { get; set; }
    public decimal TeenMinAge { get; set; }
    public decimal TeenMaxAge { get; set; }
    public decimal InfantMinAge { get; set; }
    public decimal InfantMaxAge { get; set; }
    //Aggregates
    public List<HotelLanguage> Languages { get; set; } = [];
    public List<Description> Descriptions { get; set; } = [];
    public List<Image> Images { get; set; } = [];
    public List<Room> Rooms { get; set; } = [];
    public List<SwimmingPool> SwimmingPools { get; set; } = [];
    public List<Salon> Salons { get; set; } = [];
    public List<string> Services { get; set; } = [];
    public List<string> Taxes { get; set; } = [];
}
