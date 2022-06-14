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
    public class BusModelConfig : IEntityTypeConfiguration<BusModel>
    {
        public void Configure(EntityTypeBuilder<BusModel> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasOne(b => b.BusManufacturer)
                .WithMany()
                .HasForeignKey(b => b.BusManufacturerId);

            builder.Property(b => b.SeatCapacity)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Type)
                .HasColumnType("int");

            builder.Property(x => x.HasToilet)
                .IsRequired()
                .HasColumnType("bit");

            builder.Ignore(x => x.SeatTemplate);

            builder.HasData(
                new BusModel(1, "Tourismo", 1, BusType.Coach, 44, true),
                new BusModel(2, "Travego", 1, BusType.Coach, 48, true),
                new BusModel(3, "CapaCity", 1, BusType.Coach, 52, true),

                new BusModel(4, "Escape", 4, BusType.Shuttle, 26, false),
                new BusModel(5, "Jett", 6, BusType.Shuttle, 30, false),
                new BusModel(6, "Super", 5, BusType.Shuttle, 34, true),

                new BusModel(7, "XLarge", 2, BusType.Coach, 48, true),
                new BusModel(8, "Extend", 5, BusType.Shuttle, 30, false)

                );

        }
    }
}
