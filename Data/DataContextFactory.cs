using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pam.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-JQ79203\\SQLEXPRESS;Database=PamDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            return new DataContext(optionsBuilder.Options);
        }
    }
}
