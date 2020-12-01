using System;

namespace Julius.Domain.Domains.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        private DateTime? _insertDateTime;

        public DateTime? InsertDateTime
        {
            get => _insertDateTime;
            set => _insertDateTime = value ?? DateTime.UtcNow;
        }
	}
}
