using Microsoft.EntityFrameworkCore;
using PopeyeJar.Models;

namespace PopeyeJar.Data
{
    public class PopeyeJarContext : DbContext
    {
        public PopeyeJarContext (DbContextOptions<PopeyeJarContext> options)
            : base(options)
        {
        }

        public DbSet<Jar> Jar { get; set; }
    }
}
