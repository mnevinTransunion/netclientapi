using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Domain.Entities
{
    public class Detail
    {
        public Detail()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        public string Browser { get; set; }

        public string ClientIp { get; set; }

        public string Host { get; set; }

        public Guid Id { get; set; }

        public string OS { get; set; }

        public string Referer { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserAgent { get; set; }
    }
}
