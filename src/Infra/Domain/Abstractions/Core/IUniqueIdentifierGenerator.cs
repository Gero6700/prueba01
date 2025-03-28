namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Core;

public interface IUniqueIdentifierGenerator {
    Guid Generate();
}