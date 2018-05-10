using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Domain.Entities
{
    public class Device
    {
        public Device()
        {
            this.Attributes = new Dictionary<string, string>();
            this.Timestamp = DateTime.UtcNow;
        }

        public IDictionary<string, string> Attributes { get; set; }

        public string DeviceIdentifier { get; set; }

        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
