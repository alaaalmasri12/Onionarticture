using Booky.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Booky.Repostiory.Data
{
    public class OnionBookyDbContext:DbContext
    {
        public OnionBookyDbContext(DbContextOptions<OnionBookyDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estate>().HasData(
 new Estate { Id = 1, Name = "Villa", Details = "Luxurious villa with stunning views.", Rate = 80, sqft = 150, ImageURL = "", CreateDate = new DateTime(2023, 11, 11), EstateTypeId = 1 },
 new Estate { Id = 2, Name = "House", Details = "Classic family home with a spacious backyard.", Rate = 90, sqft = 90, ImageURL = "", CreateDate = new DateTime(2023, 12, 11), EstateTypeId = 1 },
 new Estate { Id = 3, Name = "Apartment", Details = "Modern apartment in the heart of the city.", Rate = 75, sqft = 120, ImageURL = "", CreateDate = new DateTime(2023, 12, 15), EstateTypeId = 2 },
 new Estate { Id = 4, Name = "Condo", Details = "Stylish condo with amenities and city views.", Rate = 85, sqft = 100, ImageURL = "", CreateDate = new DateTime(2023, 12, 20), EstateTypeId = 2 },
 new Estate { Id = 5, Name = "Duplex", Details = "Charming duplex with a cozy atmosphere.", Rate = 95, sqft = 110, ImageURL = "", CreateDate = new DateTime(2023, 12, 25), EstateTypeId = 1 },
 new Estate { Id = 6, Name = "Townhouse", Details = "Elegant townhouse with a private garden.", Rate = 78, sqft = 130, ImageURL = "", CreateDate = new DateTime(2023, 12, 30), EstateTypeId = 1 },
 new Estate { Id = 7, Name = "Cottage", Details = "Quaint cottage in a peaceful countryside setting.", Rate = 88, sqft = 95, ImageURL = "", CreateDate = new DateTime(2024, 1, 5), EstateTypeId = 1 },
 new Estate { Id = 8, Name = "Mansion", Details = "Grand mansion with opulent interiors and vast grounds.", Rate = 105, sqft = 180, ImageURL = "", CreateDate = new DateTime(2024, 1, 10), EstateTypeId = 1 },
 new Estate { Id = 9, Name = "Studio", Details = "Compact studio with modern design and city views.", Rate = 70, sqft = 80, ImageURL = "", CreateDate = new DateTime(2024, 1, 15), EstateTypeId = 2 },
 new Estate { Id = 10, Name = "Loft", Details = "Spacious loft with industrial-chic aesthetics.", Rate = 92, sqft = 160, ImageURL = "", CreateDate = new DateTime(2024, 1, 20), EstateTypeId = 2 }
 );

            // Dummy data for PropertyType
            modelBuilder.Entity<EstateType>().HasData(
                new EstateType { Id = 1, TypeName = "Residential", Details = "Details specific to residential properties" },
                new EstateType { Id = 2, TypeName = "Commercial", Details = "Details specific to commercial properties" },
                new EstateType { Id = 3, TypeName = "Industrial", Details = "Details specific to industrial properties" }
            );

        }
        public DbSet<Estate> Estates { get; set; }

        public DbSet<EstateType> EstateType { get; set; }

    }
}
