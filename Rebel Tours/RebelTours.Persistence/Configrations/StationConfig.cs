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
    public class StationConfig : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(st => st.City)
                .WithMany()
                .HasForeignKey(st => st.CityId);


            builder.HasData(
                new Station() { Id = 1, Name = "Görele Terminal", CityId = 1 },
                new Station() { Id = 2, Name = "Bolu Terminal", CityId = 2 },
                new Station() { Id = 3, Name = "Gebze Terminal", CityId = 3 },
                new Station() { Id = 4, Name = "Osmancık Terminal", CityId = 1 },
                new Station() { Id = 5, Name = "Kaynarca Terminal", CityId = 4 }
                );

        }
    }
}
