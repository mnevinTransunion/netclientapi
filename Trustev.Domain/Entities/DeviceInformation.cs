using System;
using System.Collections.Generic;

namespace Trustev.Domain.Entities
{
    public class DeviceInformation
    {
        public Guid Id { get; set; }

        public string Result { get; set; }

        public string Reason { get; set; }

        public string StatedIp { get; set; }

        public string AccountCode { get; set; }

        public long TrackingNumber { get; set; }

        public Details Details { get; set; }
    }

    public class Details
    {
        public Ip StatedIp { get; set; }

        public Ip RealIp { get; set; }

        public RuleResults RuleResults { get; set; }

        public MachineLearning MachineLearning { get; set; }
    }

    public class MachineLearning
    {
        public MlValue1 MlValue1 { get; set; }
    }

    public class MlValue1
    {
        public long Value { get; set; }
    }

    public class Ip
    {
        public string Address { get; set; }

        public string Isp { get; set; }

        public IpLocation IpLocation { get; set; }

        public string ParentOrganization { get; set; }

        public string Source { get; set; }
    }

    public class IpLocation
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Region { get; set; }
    }

    public class RuleResults
    {
        public long Score { get; set; }

        public long RulesMatched { get; set; }

        public IList<Rule> Rules { get; set; }
    }

    public class Rule
    {
        public string Type { get; set; }

        public string Reason { get; set; }

        public long Score { get; set; }
    }
}
