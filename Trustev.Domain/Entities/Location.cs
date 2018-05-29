namespace Trustev.Domain.Entities
{
    using System;

    /// <summary>
    /// Class that aggregates all the location information gathered a post to the Location endpoint
    /// </summary>
    public class Location
    {
        public Location()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public LocationProvider Provider { get; set; }

        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Entity that represents all the information gathered around an external
    /// location information provider
    /// </summary>
    public class LocationProvider
    {
    }
}
