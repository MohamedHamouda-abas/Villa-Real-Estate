using Microsoft.EntityFrameworkCore;
using VailaPlace.Models;

namespace VailaPlace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vaila> Vailas { get; set; }
        public DbSet<LocalUser> localUsers { get; set; }
        public DbSet<VailaNumber> VailaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaila>().HasData(
              new Vaila
              {
                  Id = 1,
                  Name = "Royal Vaila",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila3.jpg",
                  Occupancy = 4,
                  Rate = 200,
                  sqft = 550,
                  Area = 23,
                  Amenity = "",
                  CreatedDate = DateTime.Now

              },
              new Vaila
              {
                  Id = 2,
                  Name = "Premium Pool Vaila",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila1.jpg",
                  Occupancy = 4,
                  Rate = 300,
                  sqft = 550,
                  Area = 23,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Vaila
              {
                  Id = 3,
                  Name = "Luxury Pool Vaila",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  sqft = 750,
                  Area = 241,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Vaila
              {
                  Id = 4,
                  Name = "Diamond Vaila",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  sqft = 900,
                  Area = 47,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Vaila
              {
                  Id = 5,
                  Name = "Diamond Pool Vaila",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  sqft = 1100,
                  Area = 243,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              }
                );

            modelBuilder.Entity<VailaNumber>().HasData(          
             new VailaNumber
             {
                 VailaNo = 1,
                 SpecialDetails ="Ther is no Updated date",
                 UpdatedDate = DateTime.Now,
                 CreatedDate = DateTime.Now
             });

        }
    }
}
