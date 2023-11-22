namespace EFCoreCodeFirstSample.Models
{
    using System;

    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class BaseEntityWithStatus : BaseEntity
    {
        public bool IsActive { get; set; }
    }
}

