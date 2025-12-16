using case_application.Data;
using case_application.Domain;
using Microsoft.EntityFrameworkCore;

namespace case_application.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Device?> GetBySerialAsync(Guid serialNumber, CancellationToken ct)
        {
            return await _context.Devices
                .SingleOrDefaultAsync(d => d.SerialNumber == serialNumber, ct);
        }

        public async Task CreateAsync(Device device, CancellationToken ct)
        {
            await _context.Devices.AddAsync(device, ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
