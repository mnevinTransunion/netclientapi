using System;

namespace Trustev.Domain.Entities
{
    public class CaseStatus
    {
        public Guid Id { get; set; }
        public Enums.CaseStatusType Status { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
