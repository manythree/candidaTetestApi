using candidateapi.Models;
using Microsoft.EntityFrameworkCore;

namespace candidateapi.Data
{
    public class AppDbContext:DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration , DbContextOptions<AppDbContext> options) :base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Candidate> Candidats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }


    }
}
