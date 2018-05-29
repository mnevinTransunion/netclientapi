using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Domain.Entities
{
    public class DetailedDecision : Decision
    {
        public string CaseNumber { get; set; }
        public string CaseId { get; set; }
        public RawData RawData { get; set; }
        public ComputedData ComputedData { get; set; }
        public DigitalAuthenticationResult Authentication { get; set; }

        /// <summary>
        /// Gets or sets authenticated data request object
        /// </summary>
        public AutoFillDetails AuthenticatedDataRequest { get; set; }
    }
   
    public class AutoFillDetails
    {
        /// <summary>
        /// Gets or sets the customer details
        /// </summary>
        public PersonalDetails Details { get; set; }

        /// <summary>
        /// Gets or sets the status of the ADR Flow
        /// </summary>
        public Enums.ADRStatus Status { get; set; }

        /// <summary>
        /// Gets this represents the description of the status
        /// </summary>
        public string StatusDescription { get; set; }
    }

       /// <summary>
    /// The personal details
    /// </summary>
    public class PersonalDetails
    {
        /// <summary>
        /// Gets or sets email Address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets city
        /// </summary>
        public string AddressCity { get; set; }

        /// <summary>
        /// Gets or sets address Country
        /// </summary>
        public string AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the Social Security Number
        /// </summary>
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the address zip code
        /// </summary>
        public string AddressZipCode { get; set; }

        /// <summary>
        /// Gets or sets the address State
        /// </summary>
        public string AddressState { get; set; }

        /// <summary>
        /// Gets or sets address street name
        /// </summary>
        public string AddressStreetName { get; set; }

        /// <summary>
        /// Gets or sets address Po Box
        /// </summary>
        public string AddressPoBox { get; set; }

        /// <summary>
        /// Gets or sets address street number
        /// </summary>
        public string AddressStreetNumber { get; set; }

        /// <summary>
        /// Gets or sets date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
    public class RawData
    {
        public Enums.CaseType CaseType { get; set; }
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
        public string SocialSecurityNumber { get; set; }
        public string PhoneNumber { get; set; }
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
        public Enums.CaseType CaseType { get; set; }
        public int DecisionsWithin1Hour { get; set; }
        public int DecisionsWithin24Hours { get; set; }
        public int DecisionsWithin7Days { get; set; }
        public int DecisionsWithin30Days { get; set; }
        public bool? IsShortTermVelocityHigh { get; set; }
        public bool IsShortTermVelocityMedium { get; set; }
        public bool? IsLongTermVelocityHigh { get; set; }
        public bool? IsLongTermVelocityMedium { get; set; }
    }

    public class ComputedDataList
    {
        public Enums.CaseType CaseType { get; set; }
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

    public class ComputedDataPhone
    {
        public bool? IsPhoneRisky { get; set; }
    }

    public class ComputedDataCustomer
    {
        public Enums.CaseType CaseType { get; set; }
        public bool? IsReturningToPlatform { get; set; }
        public bool? HasGoodHistory { get; set; }
        public bool? HasBadHistory { get; set; }
        public bool? HasSuspiciousHistory { get; set; }
        public bool? IsNameAddressCombinationValid { get; set; }
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
        public Enums.CaseType CaseType { get; set; }
        public bool? IsIPCountryDomestic { get; set; }
        public ComputedDataBIN BIN { get; set; }
    }


    public class ComputedDataAccount
    {
        public bool? CustomerHas1ExistingAccount { get; set; }

        public bool? CustomerHas2ExistingAccounts { get; set; }

        public bool? CustomerHas3ExistingAccounts { get; set; }

        public bool? CustomerHas4ExistingAccounts { get; set; }

        public bool? CustomerHasMoreThan5ExistingAccounts { get; set; }
    }

    public class ComputedData
    {
        public Enums.CaseType CaseType { get; set; }
        public ComputedDataVelocity Velocity { get; set; }
        public ComputedDataList BlackList { get; set; }
        public ComputedDataList GreyList { get; set; }
        public ComputedDataList WhiteList { get; set; }
        public ComputedDataCustomer Customer { get; set; }
        public ComputedDataTransaction Transaction { get; set; }
        public ComputedDataLocation Location { get; set; }
        public ComputedDataPhone Phone { get; set; }
        public ComputedDataAccount Account { get; set; }
    }
}
