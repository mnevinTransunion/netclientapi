namespace Trustev.Domain.Entities
{
    using System;

    public class OTPResult
    {
        public OTPResult(string apiCaseId)
        {
            this.Id = apiCaseId;
            this.Timestamp = DateTime.Now;
        }
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public Enums.OTPStatus Status { get; set; }

        public string AuthURL { get; set; }

        public string Message { get; set; }

        public string Passcode { get; set; }

        public Enums.PhoneDeliveryType? DeliveryType { get; set; }

        public Enums.OTPLanguageEnum? Language { get; set; }
    }
}