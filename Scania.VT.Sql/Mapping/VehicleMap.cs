using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Scania.VT.Entities;

namespace Scania.VT.Sql.Models.Mapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RegistrationNo)
                .HasMaxLength(10);

            this.Property(t => t.VIN)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vehicle");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegistrationNo).HasColumnName("RegistrationNo");
            this.Property(t => t.VIN).HasColumnName("VIN");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.VehicleStatusId).HasColumnName("VehicleStatusId");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.VehicleStatus)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleStatusId);

        }
    }
}
