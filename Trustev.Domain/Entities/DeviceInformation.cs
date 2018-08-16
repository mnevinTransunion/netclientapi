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
        public DetailsDevice Device { get; set; }

        public Ip StatedIp { get; set; }

        public Ip RealIp { get; set; }

        public RuleResults RuleResults { get; set; }

        public MachineLearning MachineLearning { get; set; }
    }

    public class DetailsDevice
    {
        public long Alias { get; set; }

        public BlackBoxMetadata BlackBoxMetadata { get; set; }

        public Browser Browser { get; set; }

        public string FirstSeen { get; set; }

        public bool IsNew { get; set; }

        public Mobile Mobile { get; set; }

        public string Os { get; set; }

        public RegistrationResult RegistrationResult { get; set; }

        public string Screen { get; set; }

        public string Type { get; set; }
    }

    public class BlackBoxMetadata
    {
        public int Age { get; set; }

        public string Timestamp { get; set; }
    }

    public class Browser
    {
        public string Charset { get; set; }

        public bool CookiesEnabled { get; set; }

        public string ConfiguredLanguage { get; set; }

        public Flash Flash { get; set; }

        public string Language { get; set; }

        public string Type { get; set; }

        public string Timezone { get; set; }

        public string Version { get; set; }
    }

    public class Flash
    {
        public bool Enabled { get; set; }

        public bool Installed { get; set; }

        public bool StoragedEnabled { get; set; }

        public string Version { get; set; }
    }

    public class Mobile
    {
        public App App { get; set; }

        public string Brand { get; set; }

        public Build Build { get; set; }

        public bool Charging { get; set; }

        public string Imei { get; set; }

        public MobileLocation Location { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Orientation { get; set; }

        public string ScreenResolution { get; set; }

        public MobileSystem System { get; set; }
    }

    public class App
    {
        public string BundleId { get; set; }

        public bool Debug { get; set; }

        public string ExeName { get; set; }

        public string MarketId { get; set; }

        public string Name { get; set; }

        public string Orientation { get; set; }

        public string ProcName { get; set; }

        public string SignerId { get; set; }

        public Guid VendorId { get; set; }

        public string Version { get; set; }
    }

    public class Build
    {
        public string Device { get; set; }

        public string Product { get; set; }
    }

    public class MobileLocation
    {
        public float Altitude { get; set; }

        public bool Enabled { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string Timestamp { get; set; }

        public string Timezone { get; set; }
    }

    public class MobileSystem
    {
        public bool AllowUnknownStore { get; set; }

        public string AndroidSDKLevel { get; set; }

        public string BuildFingerprint { get; set; }

        public string Carrier { get; set; }

        public string CarrierCountryCode { get; set; }

        public string CellularNetwork { get; set; }

        public string Hostname { get; set; }

        public bool JailRootDetected { get; set; }

        public string LocaleCurrency { get; set; }

        public string LocaleLang { get; set; }

        public string NetworkOperatorCountry { get; set; }

        public string NetworkOperatorName { get; set; }

        public string OsVersion { get; set; }

        public bool RootDetectionDisabled { get; set; }

        public bool Simulator { get; set; }

        public string Uptime { get; set; }

        public bool VoipAllowed { get; set; }
    }

    public class RegistrationResult
    {
        public string MatchStatus { get; set; }

        public string MeasureOfChange { get; set; }
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
