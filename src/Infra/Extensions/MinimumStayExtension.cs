namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class MinimumStayExtension {
    public static MinimumStay toMinimumStay(this Conestmi conestmi) {
        return new MinimumStay {
            Code = conestmi.GetNewCode,
            From = DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1),
            To = DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec2),
            Days = conestmi.C7dmin,
            StrictPeriod = conestmi.C7peri == 'S',
            ContractClientCode = conestmi.GetContractClientCode,
            RoomCode = conestmi.C7thab,
            RegimeCode = conestmi.C7regi
        };
    }
}
