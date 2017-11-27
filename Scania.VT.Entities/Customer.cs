namespace Scania.VT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Repository.Pattern.Ef6;
    using Scania.VT.DTO;

    public partial class Customer:Entity
    {
        public Customer()
        {
            this.Vehicles = new List<Vehicle>();
        }

        [Key]
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

   
}
