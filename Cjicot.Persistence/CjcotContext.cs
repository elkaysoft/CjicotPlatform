using Cjicot.Persistence.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence
{
    public class CjcotContext : DbContext
    {
        public CjcotContext()
        {
        }

        public CjcotContext(DbContextOptions<CjcotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<JournalCategory> JournalCategories { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Journals> Journals { get; set; }
        public virtual DbSet<JournalDocuments> JournalDocuments { get; set; }
        public virtual DbSet<JournalAuthors> JournalAuthors  { get; set;}
        public virtual DbSet<PublishedJournal> PublishedJournals { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>()
                .HasOne(b => b.UserRole)
                .WithOne(i => i.UserLogin)
                .HasForeignKey<UserRole>(b => b.UserId);

            modelBuilder.Entity<Profile>()
                .HasOne(b => b.UserLogin)
                .WithOne(i => i.Profile)
                .HasForeignKey<UserLogin>(b => b.ProfileId);

            modelBuilder.Entity<Journals>()
                .HasOne(b => b.JournalDocuments)
                .WithOne(i => i.Journals)
                .HasForeignKey<JournalDocuments>(b => b.JournalId);

            modelBuilder.Entity<Journals>()
              .HasOne(b => b.JournalAuthors)
              .WithOne(i => i.Journals)
              .HasForeignKey<JournalAuthors>(b => b.JournalId);
        }

    }
}
