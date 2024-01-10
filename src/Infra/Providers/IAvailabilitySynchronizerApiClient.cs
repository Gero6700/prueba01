using Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers {
    public interface IAvailabilitySynchronizerApiClient {
        Task<Response> PushContract(Contract contract);
    }
}
