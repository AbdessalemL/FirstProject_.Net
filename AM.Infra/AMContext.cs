using AM.applicationcore.Domain;
using AM.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infra
{
    public class AMContext:DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs{ get; set; }
        public DbSet<Traveller> Travellers { get; set; }


    //override void OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
Initial Catalog=AirportManagement4SE2;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        // Any modification doit etre ajouter ici
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //pour utiliser la builder qu'on a fait dans la Configuration
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            // configuration du type complexe( ou detenu ) FullName 
            //La propriété FirstName a une longueur maximale de 30 et le nom de la colonne 
            //correspondante à cette propriété dans la base de données doit être PassFirstName
            // la propriété LastName est obligatoire + column name est PassLastName
            modelBuilder.Entity<Passenger>().OwnsOne(fn => fn.fullName,
                full =>
                {
                    full.Property(p => p.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                    full.Property(p => p.LastName).IsRequired().HasColumnName("PassLastName");
                    //owned + contraintes de max length et obligation + changement de nom column 

                }
                );

            base.OnModelCreating(modelBuilder);
        }

        //preconvention sur le proprerties ()attribut
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //changer le nom de DataTime to affiche Date
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
            // le max taille de string 100
            //configurationBuilder.Properties<String>().HaveMaxLength(100);
            base.ConfigureConventions(configurationBuilder);
        }
    
    }
}
