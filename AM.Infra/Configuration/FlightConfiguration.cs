using AM.applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infra.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity(t => t.ToTable("VolsPassengers")); //to change the name of table associative
          
            
            /*  builder.HasOne(f => f.planes)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.planes)
                   .OnDelete(DeleteBehavior.Cascade); //Foreign key , one-to-many
          */
        }
    }
}
