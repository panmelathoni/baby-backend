using babyApi.domain;
using Microsoft.EntityFrameworkCore;

namespace babyApi.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BabyProfile> Babies { get; set; }
        public DbSet<BabyActivity> BabiesActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}