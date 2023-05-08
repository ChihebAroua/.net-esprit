using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class TicketConfiguration: IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PassengerFK, t.FlightFK });
            builder.HasOne(f => f.PassengerP).WithMany(p => p.Tickets).HasForeignKey(f => f.PassengerFK).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(f => f.FlightP).WithMany(p => p.Tickets).HasForeignKey(f => f.FlightFK).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
