namespace Scania.VT.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Repository.Pattern.Ef6;

    public partial class VehicleStatus:Entity
    {
        public VehicleStatus()
        {
            this.Vehicles = new List<Vehicle>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
