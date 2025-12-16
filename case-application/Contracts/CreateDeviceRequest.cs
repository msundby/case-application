using System.ComponentModel.DataAnnotations;
using case_application.Domain;

namespace case_application.Contracts
{
    public class CreateDeviceRequest
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string ModelId { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string Manufacturer { get; set; }

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
