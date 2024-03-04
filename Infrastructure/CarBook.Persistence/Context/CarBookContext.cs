using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Context
{
    public class CarBookContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AARDBEI;Initial Catalog=CarBookDB;User Id=sa;Password=Haxl;TrustServerCertificate=True;MultipleActiveResultSets=true;");


        }
        public DbSet<About>Abouts { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location>Locations { get; set; }
        public DbSet<Pricing>Pricings { get; set;}
        public DbSet<Service> Services { get; set; }

        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Testimonial> Testsimonials { get; set; }    
    }
}
