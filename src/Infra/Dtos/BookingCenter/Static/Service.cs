namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Service{
    public string Code { get; set; } = string.Empty;
    public string CategoryCode { get; set; } = string.Empty;
    public List<ServiceTranslation> Translations { get; set; } = [];
}
