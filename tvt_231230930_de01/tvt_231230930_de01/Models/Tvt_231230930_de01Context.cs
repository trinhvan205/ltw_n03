using Microsoft.EntityFrameworkCore;
namespace Tvt_231230930_de01.Models
{
    public class Tvt_231230930_de01Context: DbContext
    {
        public Tvt_231230930_de01Context (DbContextOptions<Tvt_231230930_de01Context> options)
            : base(options)
        {
        }
        public DbSet<TvtComputer> TvtComputers { get; set; }
    
    }
}
