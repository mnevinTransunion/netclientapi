using System;

namespace Trustev.Domain.Entities
{
    public class Decision
    {
        public Guid Id { get; set; }

        public string CaseId { get; set; }

        public int Version { get; set; }

        public Guid SessionId { get; set; }

        public DateTime Timestamp { get; set; }

        public int Type { get; set; }

        public Enums.DecisionResult Result { get; set; }

        public int Score { get; set; }

        public int Confidence { get; set; }

        public string Comment { get; set; }
    }
}
