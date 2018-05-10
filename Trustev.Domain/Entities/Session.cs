using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Domain.Entities
{
    public class Session
    {
        public Session()
        {
            SessionId = Guid.Empty;
            SessionType = Enums.SessionType.JavaScript;
            Details = new List<Detail>();
            Devices = new List<Device>();
            Locations = new List<Location>();
        }

        public IList<Detail> Details { get; set; }

        public IList<Device> Devices { get; set; }

        public IList<Location> Locations { get; set; }

        public Guid SessionId { get; set; }

        public Enums.SessionType SessionType { get; set; }
    }
}
