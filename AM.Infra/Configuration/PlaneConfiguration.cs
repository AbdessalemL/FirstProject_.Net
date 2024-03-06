using AM.applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infra.Configuration

{// tp partie 4
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        //fluent api ,pour faire la configuration
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.Planeid); // equivalent l'annotation [key]
            builder.ToTable("MyPlanes");  //renommer la table
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity"); // to change column name
            


        }
    }
}
