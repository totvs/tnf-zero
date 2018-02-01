using Microsoft.EntityFrameworkCore;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace Tnf.Zero.EntityFrameworkCore
{
    public class ZeroContext : TnfDbContext
    {
        public ZeroContext(DbContextOptions<ZeroContext> options, ITnfSession session) 
            : base(options, session)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
