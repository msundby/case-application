using case_application.Domain;

namespace case_application.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device?> GetBySerialAsync(Guid serialNumber, CancellationToken ct);
        Task CreateAsync(Device device, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
