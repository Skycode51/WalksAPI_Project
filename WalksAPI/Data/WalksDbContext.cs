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


    }
}
