namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ResthabiExtension {
    public static RoomDto ToRoom(this Resthabi resthabi) {
        return new RoomDto {
            Code = resthabi.Mthab
        };
    }

}
