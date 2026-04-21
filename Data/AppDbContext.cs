using Microsoft.EntityFrameworkCore;
using SaoJoaoVote.Models;

namespace SaoJoaoVote.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Voto> Votos { get; set; }
    }
}