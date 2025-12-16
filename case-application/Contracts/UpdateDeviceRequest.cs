using System.ComponentModel.DataAnnotations;
using case_application.Domain;

namespace case_application.Contracts
{
    public class UpdateDeviceRequest
    {
        [Required, EmailAddress]
        public string PrimaryUserEmail { get; set; }

        [Required]
        public string OperatingSystem { get; set; }

        [Required]
        public DeviceType DeviceType { get; set; }

        [Required]
        public DeviceStatus Status { get; set; }
    }
}
