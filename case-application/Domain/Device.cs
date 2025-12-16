using System.ComponentModel.DataAnnotations;

namespace case_application.Domain
{
    public class Device
    {
        public long Id { get; private set; }
        public Guid SerialNumber { get; private set; }
        public string ModelId { get; private set; }
        public string ModelName { get; private set; }
        public string Manufacturer { get; private set; }
        public string PrimaryUserEmail { get; private set; }
        public string OperatingSystem { get; private set; }
        public DeviceType DeviceType { get; private set; }
        public DeviceStatus Status { get; private set; }

        protected Device() { }

        public Device( 
            Guid serialNumber,
            string modelId,
            string modelName,
            string manufacturer,
            string primaryUserEmail,
            string operatingSystem,
            DeviceType deviceType,
            DeviceStatus status    
            )
        {
            SerialNumber = serialNumber;
            ModelId = modelId;
            ModelName = modelName;
            Manufacturer = manufacturer;

            Update(primaryUserEmail, operatingSystem, deviceType, status);
        }

        public void Update(
            string primaryUserEmail,
            string operatingSystem,
            DeviceType deviceType,
            DeviceStatus status)
        {
            if(!new EmailAddressAttribute().IsValid(primaryUserEmail))
            {
                throw new ValidationException("Invalid primary user email");
            }

            PrimaryUserEmail = primaryUserEmail;
            OperatingSystem = operatingSystem;
            DeviceType = deviceType;
            Status = status;
        }
    }
}
