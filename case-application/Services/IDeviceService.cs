using case_application.Contracts;

namespace case_application.Services
{
    public interface IDeviceService
    {
        Task Create(CreateDeviceRequest request, CancellationToken ct);
        Task Update(string serialNumber, UpdateDeviceRequest request, CancellationToken ct);
    }
}
