using DanderiNetwork.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DanderiNetwork.Infraestructure.Persistence.Contexts
{
  
   public class ApplicationContext : DbContext
   {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Tables

            modelBuilder.Entity<Comment>()
                .ToTable("Comments");

            modelBuilder.Entity<Following>()
              .ToTable("Following");

            modelBuilder.Entity<Post>()
              .ToTable("Posts");




            #endregion

            #region Primary Keys

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<Post>()
            .HasKey(c => c.ID);

            modelBuilder.Entity<Following>()
            .HasKey(c => c.ID);


            #endregion

            #region Relationships

            modelBuilder.Entity<Post>()
                .HasMany(d => d.Comments)
                .WithOne(a => a.Post)
                .HasForeignKey(a => a.PostID)
                .OnDelete(DeleteBehavior.Cascade);


           
            #endregion

            #region Property Configuration

            #region Comment

            modelBuilder.Entity<Comment>().
               Property(d => d.Content)
            .IsRequired();

            modelBuilder.Entity<Comment>().
               Property(d => d.Created)
            .IsRequired();


            #endregion

            #region Post

            modelBuilder.Entity<Post>().
               Property(d => d.Created)
            .IsRequired();


            #endregion







            #endregion





        }





    }
}
