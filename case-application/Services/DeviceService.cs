using System.ComponentModel.DataAnnotations;
using case_application.Contracts;
using case_application.Domain;
using case_application.Exceptions;
using case_application.Repositories;

namespace case_application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateDeviceRequest request, CancellationToken ct)
        {
            if (!Guid.TryParse(request.SerialNumber, out var serial))
            {
                throw new ValidationException("Serial number must be a valid GUID");
            }

            var existing = await _repository.GetBySerialAsync(serial, ct);
            if (existing != null)
            {
                throw new ConflictException("Device already exists"); 
            }

            var device = new Device(
                serial,
                request.ModelId,
                request.ModelName,
                request.Manufacturer,
                request.PrimaryUserEmail,
                request.OperatingSystem,
                request.DeviceType,
                request.Status
            );

            await _repository.CreateAsync(device, ct);
            await _repository.SaveChangesAsync(ct);
        }

        public async Task Update(string serialNumber, UpdateDeviceRequest request, CancellationToken ct)
        {
            if (!Guid.TryParse(serialNumber, out var guid))
            {
                throw new ValidationException("Serial number must be a valid GUID");
            }

            var device = (await _repository.GetBySerialAsync(guid, ct))
            ?? throw new NotFoundException("Device not found");

            device.Update(
                request.PrimaryUserEmail,
                request.OperatingSystem,
                request.DeviceType,
                request.Status
                );

            await _repository.SaveChangesAsync(ct);
        }
    }
}
