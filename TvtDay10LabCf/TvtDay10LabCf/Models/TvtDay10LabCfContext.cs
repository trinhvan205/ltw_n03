using Microsoft.EntityFrameworkCore;
namespace TvtDay10LabCf.Models
{
    public class TvtDay10LabCfContext: DbContext
    {
        public TvtDay10LabCfContext(DbContextOptions<TvtDay10LabCfContext> options) : base(options) { }
        
            public DbSet<TvtLoai_San_Pham> tvtLoai_San_Phams { get; set; }
            public DbSet<TvtSan_Pham> tvtSan_Phams { get; set; }
        
    }
}
