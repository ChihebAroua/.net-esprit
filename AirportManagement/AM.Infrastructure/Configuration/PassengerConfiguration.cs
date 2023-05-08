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
    public class PassengerConfiguration :  IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasDiscriminator<int>("isTraveller").HasValue<Passenger>(0).HasValue<Traveller>(1).HasValue<Staff>(3);
            builder.OwnsOne(p => p.Fullname,
                
                j => { 
                    j.Property(f => f.FirstName).HasColumnName("Firstname"); 
                    j.Property(f => f.LastName).HasColumnName("Lastname"); 
                });
        }
    }
}
