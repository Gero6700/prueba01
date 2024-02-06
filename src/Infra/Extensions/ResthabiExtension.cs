namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ResthabiExtension {
    public static Room ToRoom(this Resthabi resthabi) {
        return new Room {
            Code = resthabi.Mthab
        };
    }
    
}
