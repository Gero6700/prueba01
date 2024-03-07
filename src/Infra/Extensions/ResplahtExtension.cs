namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;

public static class ResplahtExtension
{
    public static Infrastructure.Dtos.BookingCenter.Inventory ToInventory(this Resplaht resplaht) {
        return new Infrastructure.Dtos.BookingCenter.Inventory {
            InventoryDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(resplaht.Ptfec),
            RoomQuantity = resplaht.GetRoomQuantity,
            HotelCode = resplaht.Pthot.ToString(),
            RoomCode = resplaht.Pthab
        };
    }
}
