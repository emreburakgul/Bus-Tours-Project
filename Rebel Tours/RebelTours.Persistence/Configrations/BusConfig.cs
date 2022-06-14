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
    public class BusConfig : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.BusModel)
                .WithMany()
                .HasForeignKey(b => b.BusModelId);

            builder.Property(b => b.RegistrationPlate)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(b => b.Year)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(b => b.SeatMapping)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(b => b.DistanceTraveled)
                .IsRequired()
                .HasColumnType("int");


            builder.HasData(
                new Bus(1,1,"34 GMB 36",2011,SeatingType.Deluxe,10000),
                new Bus(2,3,"34 GDT 18",2012,SeatingType.Premium,10000),
                new Bus(3,2,"34 ASL 422",1990,SeatingType.Standart,10000),
                new Bus(4,4,"34 EBG 28",1998,SeatingType.Premium,10000)                
                );

        }

    }
}
