using System.ComponentModel.DataAnnotations;
using case_application.Contracts;
using case_application.Exceptions;
using case_application.Services;
using Microsoft.AspNetCore.Mvc;

namespace case_application.Controllers
{
    [ApiController]
    [Route("api/v1/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDeviceRequest request, CancellationToken ct)
        {
            try
            {
                await _deviceService.Create(request, ct);
                return CreatedAtAction(nameof(Create), new { id = request.SerialNumber }, request);
            }
            
            catch(ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{serialNumber}")]
        public async Task<ActionResult> Update(string serialNumber, [FromBody] UpdateDeviceRequest request, CancellationToken ct)
        {
            try
            {
                await _deviceService.Update(serialNumber, request, ct);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }

}
