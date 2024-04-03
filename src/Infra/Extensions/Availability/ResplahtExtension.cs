using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ResplahtExtension {
    public static Inventory ToInventory(this Resplaht resplaht) {
        return new Inventory {
            InventoryDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(resplaht.Ptfec),
            RoomQuantity = resplaht.GetRoomQuantity,
            HotelCode = resplaht.Pthot.ToString(),
            RoomCode = resplaht.Pthab
        };
    }
}
