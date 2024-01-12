using Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers {
    public interface IAvailabilitySynchronizerApiClient {
        Task<Response> CreateContract(Contract contract);
        Task<Response> CreateContractClient(ContractClient contractClient);
        Task<Response> UpdateContract(Contract contract);
        Task<Response> UpdateContractClient(ContractClient contractClient);
        Task<Response> DeleteContract(string codContract);
    }
}
