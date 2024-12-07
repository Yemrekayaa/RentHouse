using Microsoft.EntityFrameworkCore;
using RentHouse.Domain.Entities;

namespace RentHouse.Persistence.Context
{
    public class RentHouseContext : DbContext
    {
        public RentHouseContext(DbContextOptions<RentHouseContext> options) : base(options)
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseFeature> HouseFeatures { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Price alan�n� decimal(18,8) olarak ayarl�yoruz
            modelBuilder.Entity<House>()
                .Property(h => h.Longitude)
                .HasColumnType("decimal(18,8)");
            modelBuilder.Entity<House>()
                .Property(h => h.Latitude)
                .HasColumnType("decimal(18,8)");
        }
    }
}
