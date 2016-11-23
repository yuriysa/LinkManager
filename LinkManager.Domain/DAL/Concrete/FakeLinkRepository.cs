using System;
using System.Collections.Generic;
using System.Linq;
using LinkManager.Domain.DAL.Abstract;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.DAL.Concrete
{
    public class FakeLinkRepository : ILinkRepository
    {
        private List<Link> data = new List<Link>
        {
            new Link { OriginalString = "http://google.com", LinkID = ++_count},
            new Link { OriginalString = "http://bing.com", LinkID = ++_count},
            new Link { OriginalString = "http://yahoo.com", LinkID = ++_count}
        };

        private static int _count = 0;

        public IEnumerable<Link> GetAllLinks() => data.AsEnumerable();

        public Link GetLink(int id) => data.Where(r => r.LinkID == id).FirstOrDefault();

        public void Add(Link link)
        {
            link.LinkID = ++_count;
            link.CreatedDate = DateTime.Now;
            data.Add(link);
        }

        public void Update(Link link)
        {
            Link item = GetLink(link.LinkID);

            if (item != null)
            {
                item.OriginalString = link.OriginalString;
                item.CreatedDate = DateTime.Now;
            }
        }

        public void Delete(int id)
        {
            Link item = GetLink(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }
    }
}