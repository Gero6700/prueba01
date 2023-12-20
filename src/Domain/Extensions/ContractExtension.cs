namespace Senator.As400.Cloud.Sync.Application.Extensions; 

public static class ContractExtension {
    public static Contract MapToContract(this Concabec concabec) {
        return new Contract {
            Agency = concabec.Coagen,
            Branch = concabec.Cosucu,
            HotelCode = concabec.Cohote,
            ContractCode = concabec.Cocont,
            StartDate = new DateTime(concabec.Cofec1, 1, 1),
            EndDate = new DateTime(concabec.Cofec2, 1, 1)
        };
    }
}