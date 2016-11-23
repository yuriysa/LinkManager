using System.Collections.Generic;
using LinkManager.Domain.Entities;

namespace LinkManager.Domain.DAL.Abstract
{
    public interface ILinkRepository
    {
        IEnumerable<Link> GetAllLinks();
        Link GetLink(int id);
        void Add(Link link);
        void Update(Link link);
        void Delete(int id);
    }
}