using Adventure.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Adventure.Repository
{
    public class AdventureDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Adventure;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        public AdventureDbContext(DbContextOptions<AdventureDbContext> options):base(options)
        {
            
        }

        public AdventureDbContext() : base()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
             .HasOne<User>(s => s.User)
             .WithMany(g => g.Question)
             .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<User>()
             .HasMany<Question>(g => g.Question)
             .WithOne(s => s.User)
             .HasForeignKey(s => s.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdventureType>()
                .HasMany<AdventureDetail>(g => g.AdventureDetail)
                .WithOne(s => s.AdventureType)
                .HasForeignKey(s => s.AdventureTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdventureDetail>()
             .HasOne<AdventureType>(s => s.AdventureType)
             .WithMany(g => g.AdventureDetail)
             .HasForeignKey(s => s.AdventureTypeId);

        
            modelBuilder.Entity<UserAdventure>().HasKey(sc => new { sc.AdventureDetailId, sc.UserId });

            modelBuilder.Entity<UserAdventure>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserAdventure)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserAdventure>()
                .HasOne<AdventureDetail>(sc => sc.AdventureDetail)
                .WithMany(s => s.UserAdventure)
                .HasForeignKey(sc => sc.AdventureDetailId);

        }

        public DbSet<AdventureDetail> AdventureDetail { get; set; }
        public DbSet<AdventureType> AdventureType { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAdventure> UserAdventure { get; set; }


        

    }
}
