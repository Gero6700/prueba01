using Senator.As400.Cloud.Sync.Application.Exceptions;

namespace Senator.As400.Cloud.Sync.Application.UseCases; 

public class SynchronizeContract {
    public Task Execute(Concabec concabec) {
        try {
            var contact = concabec.MapToContract();
            return Task.CompletedTask;
        }
        catch {
            throw new ContractMappingFailedException();
        }
        return Task.CompletedTask;
    }
}