using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("MyFlights");
            builder.Property(f => f.Departure).HasMaxLength(50).IsRequired().HasColumnName("Departure Town");
           // builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(j=>j.ToTable("MyReservation"));
        }

    }
}