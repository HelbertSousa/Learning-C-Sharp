using Microsoft.EntityFrameworkCore;

namespace MinimalCrud.Data
{
    public class ApDbContext(DbContextOptions<ApDbContext> options) : DbContext(options)
    {
        public DbSet<Model.StudentModel> Students { get; set; }
    }
}
