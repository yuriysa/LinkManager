using System.Data.Entity;

namespace LinkManager.Domain.DAL
{
    public class EFDbContext : DbContext
    {
        public DbSet<Entities.Link> Links { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}