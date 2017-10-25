namespace Trustev.Domain.Entities
{
      /// <summary>
    /// Fulfilment for case
    /// </summary>
    public class Fulfilment
    {
       /// <summary>
       /// TimeToFulfilment
       /// </summary>
       public Enums.TimeToFulfilment TimeToFulfilment { get; set; }
        /// <summary>
        /// Method
        /// </summary>
        public Enums.FulfilmentMethod Method { get; set; }
        /// <summary>
        /// GeoLocation
        /// </summary>
        public Enums.FulfilmentGeoLocation GeoLocation { get; set; }
    }
}