using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GPP.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        public DbSet<MessageModel> Messages{ get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Profession>()
        .HasMany(c => c.applicationUsers)
        .WithOne(e => e.Profession)
        .HasForeignKey(e=>e.ProfessionId);

            modelBuilder.Entity<Gig>()
                .HasKey(g => g.GigId);

            modelBuilder.Entity<Profession>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Gig>(entity =>
            entity.HasOne(u => u.applicationUser)
            .WithMany(g => g.Gigs)
            .HasForeignKey(g => g.UserId)
                       
            );


            modelBuilder.Entity<Gig>(entity =>
            entity.HasOne(u => u.Profession)
            .WithMany(g => g.Gigs)
            .HasForeignKey(g => g.ProfessionId)

            );

            modelBuilder.Entity<MessageModel>()
               .HasKey(p => p.id);


        }
    }
}
