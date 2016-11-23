using System;

namespace LinkManager.Domain.Entities
{
    public class Link
    {
        public int LinkID { get; set; }
        public string OriginalString { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}