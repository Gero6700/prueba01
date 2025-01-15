namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ResplahtExtension {
    public static InventoryDto ToInventory(this Resplaht resplaht) {
        return new InventoryDto {
            InventoryDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(resplaht.Ptfec),
            RoomQuantity = resplaht.GetRoomQuantity,
            OccupiedRooms = resplaht.GetOccupiedRooms,
            HotelCode = resplaht.Pthot.ToString(),
            RoomCode = resplaht.Pthab
        };
    }
}
