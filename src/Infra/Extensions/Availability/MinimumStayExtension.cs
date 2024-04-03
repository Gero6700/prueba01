using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class MinimumStayExtension {
    public static MinimumStay toMinimumStay(this Conestmi conestmi) {
        return new MinimumStay {
            Code = conestmi.Code,
            From = DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec1),
            To = DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec2),
            Days = conestmi.C7dmin,
            StrictPeriod = conestmi.C7peri.ToString().ToUpper() == "S",
            ContractClientCode = conestmi.ContractClientCode,
            RoomCode = conestmi.C7thab,
            RegimeCode = conestmi.C7regi
        };
    }
}
