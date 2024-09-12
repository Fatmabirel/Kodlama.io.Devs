using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext 
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Kodlama.io-DevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies); // a ProgrammingLanguage has one or more Technology
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage); // a Technology has one ProgrammingLanguage
            });

            modelBuilder.Entity<SocialMediaAddress>(a =>
            {
                a.ToTable("SocialMediaAddresses").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
                a.Property(p => p.LinkedinUrl).HasColumnName("LinkedinUrl");
                a.Property(p => p.TwitterUrl).HasColumnName("TwitterUrl");
                a.Property(p => p.MediumUrl).HasColumnName("MediumUrl");
                a.Property(p => p.PersonalWebSiteUrl).HasColumnName("PersonalWebSiteUrl");
                a.HasOne(s => s.User); 
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(5, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, 5, "Django") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

        }
    }
}
