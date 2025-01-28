namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class MinimumStayExtension {
    public static MinimumStayDto toMinimumStay(this Conestmi conestmi) {
        return new MinimumStayDto {
            Code = conestmi.Code,
            From = DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec1),
            To = DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec2),
            Nights = conestmi.C7dmin,
            StrictPeriod = conestmi.C7peri.ToString().ToUpper() == "S",
            IntegrationContractCode = conestmi.ContractClientCode,
            RoomCode = conestmi.C7thab.Trim() == "" ? null : conestmi.C7thab,
            MealCode = conestmi.C7regi.Trim() == "" ? null : conestmi.C7regi
        };
    }
}
