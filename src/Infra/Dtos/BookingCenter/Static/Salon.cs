namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Salon : IAggregateRoot{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Surface { get; set; }
    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Height { get; set; }
    public int FeastCapacity { get; set; }
    public int CocktailCapacity { get; set; }
    public int ImperialCapacity { get; set; }
    public int UCapacity { get; set; }
    public int ClassroomCapacity { get; set; }
    public List<Translation> Translations { get; set; } = [];
    public List<Image> Images { get; set; } = [];
}
