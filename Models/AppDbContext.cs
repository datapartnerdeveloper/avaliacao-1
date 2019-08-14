using Microsoft.EntityFrameworkCore;

namespace avaliacoes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opions) : base(opions)
        {

        }
        
        public DbSet<Avaliacao> Avaliacao {get; set;}
    }


}