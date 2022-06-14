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
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.HasData(
                new City() { Id = 1, Name = "İstanbul" },
                new City() { Id = 2, Name = "İzmir" },
                new City() { Id = 3, Name = "Mersin" },
                new City() { Id = 4, Name = "Giresun" },
                new City() { Id = 5, Name = "Adana" }
                );
        }
    }
}
