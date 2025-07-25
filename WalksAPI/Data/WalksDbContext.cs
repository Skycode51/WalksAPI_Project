using Microsoft.EntityFrameworkCore;
using WalksAPI.Models.Domain;

namespace WalksAPI.Data
{
    public class WalksDbContext : DbContext
    {
        //Create Constructor for this class
        public WalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        //Create DbSet for Walks, Regions and Difficulty
        // this will create the tables in the database
        public  DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Regions> regions { get; set; }
        public DbSet<Walks> walks { get; set; }


      //Override the OnModelCreating method to configure the model
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // easy, Medium, Hard

            var difficulties = new List <Difficulty>()
            {
                new Difficulty()
                {
                    Id =Guid.Parse("158c5470-7990-40c0-a0c2-0884cfd0378f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a2a31082-c3c7-4e96-96a4-43d662e06d6f"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("b6f10401-c0da-4674-a5cd-20a8680ea0a3"),
                    Name = "Hard"
                }
            };

             //Seed difficulites to database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for region 
            var regions = new List<Regions>
            {

                new Regions()
                {
                    Id = Guid.Parse("f1c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"),
                    Name = "North Region",
                    Code = "NR",
                    RegionImageUrl = "https://example.com/north-region.jpg"
                },
                new Regions()
                {
                    Id = Guid.Parse("d2c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"),
                    Name = "South Region",
                    Code = "SR",
                    RegionImageUrl = "https://example.com/south-region.jpg"
                },
                new Regions()
                {
                    Id = Guid.Parse("c3b0d2f1-4e8a-4c5b-9f6d-7e8f9a0b1c2d"),
                    Name = "East Region",
                    Code = "ER",
                    RegionImageUrl = "https://example.com/east-region.jpg"
                },
                new Regions()
                {
                     Id = Guid.Parse("b0d2f1c3-4e8a-4c5b-9f6d-7e8f9a0b1c2d"),
                     Name = "West Region",
                     Code = "WR",
                     RegionImageUrl = "https://example.com/west-region.jpg"
                }
            };


            modelBuilder.Entity<Regions>().HasData(regions);
           
        }

    }
}
