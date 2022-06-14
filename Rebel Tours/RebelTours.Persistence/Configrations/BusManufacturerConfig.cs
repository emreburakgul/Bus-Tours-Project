using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Persistence.Configrations
{
    public class BusManufacturerConfig : IEntityTypeConfiguration<BusManufacturer>
    {
        public void Configure(EntityTypeBuilder<BusManufacturer> builder)
        {
            builder.HasKey(bm => bm.Id);
            builder.Property(bm => bm.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.HasData(
                new BusManufacturer(1, "Mercedes"),
                new BusManufacturer(2, "MAN"),
                new BusManufacturer(3, "Volvo"),
                new BusManufacturer(4, "Renault"),
                new BusManufacturer(5, "Togg"),
                new BusManufacturer(6, "Karsan")
                );
        }
    }
}
