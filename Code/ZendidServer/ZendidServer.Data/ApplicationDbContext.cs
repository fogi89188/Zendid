using Microsoft.EntityFrameworkCore;
using System;
using ZendidServer.Data.Models;

namespace ZendidServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Tokens)
                .WithOne(x => x.User);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Friends)
                .WithOne(x => x.User);

            modelBuilder.Entity<UserFriend>()
                .HasOne(x => x.Friend)
                .WithMany(x => x.FriendOf);




        }
    }
}
