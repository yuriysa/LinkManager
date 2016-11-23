using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LinkManager.Domain.DAL.Abstract;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.DAL.Concrete
{
    public class LinkRepository : ILinkRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Link> GetAllLinks() => context.Links;

        public Link GetLink(int id) => context.Links.Where(r => r.LinkID == id).FirstOrDefault();

        public void Add(Link link)
        {
            context.Entry(link).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Link link)
        {
            Link item = GetLink(link.LinkID);
            if (item != null)
            {
                link.OriginalString = item.OriginalString;
                link.CreatedDate = item.CreatedDate;

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
    }

        public void Delete(int id)
        {
            Link item = GetLink(id);
            if (item != null)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
        }
    }
}