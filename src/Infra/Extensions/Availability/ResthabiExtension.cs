namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ResthabiExtension {
    public static Dtos.BookingCenter.Availability.Room ToRoom(this Resthabi resthabi) {
        return new Dtos.BookingCenter.Availability.Room
        {
            Code = resthabi.Mthab
        };
    }

}
