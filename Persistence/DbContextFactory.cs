using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();
            dbContextBuilder.UseSqlServer("Data Source=Milan;Initial Catalog=Perfumes;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new DataContext(dbContextBuilder.Options);
        }
    }
}
