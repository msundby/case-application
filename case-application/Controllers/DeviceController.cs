using System.ComponentModel.DataAnnotations;
using case_application.Contracts;
using case_application.Services;
using Microsoft.AspNetCore.Mvc;

namespace case_application.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDeviceRequest request, CancellationToken ct)
        {
            try
            {
                await _deviceService.Create(request, ct);
                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{serialNumber}")]
        public async Task<ActionResult> Update(string serialNumber, [FromBody] UpdateDeviceRequest request, CancellationToken ct)
        {
            if(!Guid.TryParse(serialNumber, out var guid))
            {
                return BadRequest("Serial number must be a valid GUID");
            }

            try
            {
                await _deviceService.Update(guid, request, ct);
                return NoContent();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
