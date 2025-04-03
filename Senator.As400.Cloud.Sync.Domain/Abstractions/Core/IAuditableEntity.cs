namespace Senator.As400.Cloud.Sync.Domain.Abstractions.Core;

public interface IAuditableEntity {
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}