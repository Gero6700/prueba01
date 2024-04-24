namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Room : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Surface { get; set; }
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }
    public int MinInfants { get; set; }
    public int MaxInfants { get; set; }
    public int MinChildren { get; set; }
    public int MaxChildren { get; set; }
    public int? MinTeens { get; set; }
    public int? MaxTeens { get; set; }
    public int MinAdults { get; set; }
    public int MaxAdults { get; set; }
    public List<Equipment> Equipments { get; set; } = [];
    public List<Bed> Beds { get; set; } = [];
    public List<Image> Images { get; set; } = [];
    public List<RoomTranslation> Translations { get; set; } = [];
}
