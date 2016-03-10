using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Domain.Entities
{
    public class DetailedDecision : Decision
    {
        public string CaseNumber { get; set; }
        public RawData RawData { get; set; }
        public ComputedData ComputedData { get; set; }
    }

    public class RawData
    {
        public string DeviceTag { get; set; }
        public string TrustevCustomerId { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string NavigatorOscpu { get; set; }
        public string NavigatorLanguage { get; set; }
        public string NavigatorPlugins { get; set; }
        public string ScreenWidth { get; set; }
        public string ScreenHeight { get; set; }
        public string ScreenColorDepth { get; set; }
        public IList<RawDataIPAddress> IPAddresses { get; set; }
        public RawDataBINInformation BINInformation { get; set; }
        public RawDataCustomer Customer { get; set; }
        public RawDataTransaction Transaction { get; set; }
    }

    public class RawDataEmail
    {
        public string EmailAddress { get; set; }
    }

    public class RawDataCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<RawDataEmail> Emails { get; set; }
    }

    public class RawDataTransaction
    {
        public IList<RawDataEmail> Emails { get; set; }
    }

    public class RawDataBINInformation
    {
        public string BIN { get; set; }
        public string Brand { get; set; }
        public string CountryISO3166_Code2 { get; set; }
        public string CardType { get; set; }
        public string Bank { get; set; }
    }

    public class RawDataIPAddress
    {
        public string Id { get; set; }
        public string ClientIp { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ConnectionType { get; set; }
        public string LineSpeed { get; set; }
        public string RoutingType { get; set; }
        public string SLD { get; set; }
        public string TLD { get; set; }
        public string HostingFacility { get; set; }
        public string ProxyType { get; set; }
        public string AnonymizerStatus { get; set; }
    }

    public class ComputedDataVelocity
    {
        public int DecisionsWithin1Hour { get; set; }
        public int DecisionsWithin24Hours { get; set; }
        public int DecisionsWithin7Days { get; set; }
        public int DecisionsWithin30Days { get; set; }
    }

    public class ComputedDataList
    {
        public bool? WasBinHit { get; set; }
        public bool? WasEmailDomainHit { get; set; }
        public bool? WasFullEmailAddressHit { get; set; }
        public bool? WasPostCodeHit { get; set; }
        public bool? WasCustomerIdHit { get; set; }
        public bool? WasAccountNumberHit { get; set; }
        public bool? WasIPHit { get; set; }
    }

    public class ComputedDataEmail
    {
        public bool? IsDisposable { get; set; }
        public bool? IsDomainNotAllowed { get; set; }
        public bool? IsUserNameNotAllowed { get; set; }
        public bool? ContainsDomainIssue { get; set; }
        public bool? ContainsMailboxIssue { get; set; }
        public bool? ContainsSyntaxIssue { get; set; }
    }

    public class ComputedDataCustomer
    {
        public bool? IsReturningToPlatform { get; set; }
        public bool? HasGoodHistory { get; set; }
        public bool? HasBadHistory { get; set; }
        public bool? HasSuspiciousHistory { get; set; }
        public ComputedDataEmail Email { get; set; }
    }
    public class ComputedDataTransaction
    {
        public ComputedDataEmail Email { get; set; }
    }

    public class ComputedDataBIN
    {
        public bool? DoesMatchCustomerBillingAddressCountry { get; set; }
        public bool? DoesMatchCustomerDeliveryAddressCountry { get; set; }
        public bool? DoesMatchTransactionBillingAddressCountry { get; set; }
        public bool? DoesMatchTransactionDeliveryAddressCountry { get; set; }
        public bool? DoesMatchIPCountry { get; set; }
        public bool? IsCountryDomestic { get; set; }
    }

    public class ComputedDataLocation
    {
        public bool? IsIPCountryDomestic { get; set; }
        public ComputedDataBIN BIN { get; set; }
    }

    public class ComputedData
    {
        public ComputedDataVelocity Velocity { get; set; }
        public ComputedDataList BlackList { get; set; }
        public ComputedDataList GreyList { get; set; }
        public ComputedDataList WhiteList { get; set; }
        public ComputedDataCustomer Customer { get; set; }
        public ComputedDataTransaction Transaction { get; set; }
        public ComputedDataLocation Location { get; set; }
    }
}
