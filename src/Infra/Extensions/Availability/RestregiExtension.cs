namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class RestregiExtension {
    public static MealDto ToRegime(this Restregi restregi) {
        return new MealDto {
            Code = restregi.Mrhab,
            Order = restregi.Roorde
        };
    }
}
