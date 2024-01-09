using Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers {
    public interface IAvailabilitySynchronizerApiClient {
        Task<Response> PushContract(Contract contract);
        //Task<Response> PushContractClient(ContractClient contract);
    }
}
