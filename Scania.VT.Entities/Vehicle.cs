namespace Scania.VT.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Repository.Pattern.Ef6;

    public partial class Vehicle:Entity
    {
        [Key]
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string VIN { get; set; }
        public long CustomerId { get; set; }
        public int VehicleStatusId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual VehicleStatus VehicleStatus { get; set; }
    }
}
