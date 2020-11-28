using System;
using SW.PrimitiveTypes;

namespace SW.Surl.Domain
{
    public class ShortenedUrl : BaseEntity<string> 
    {
        public string FullUrl { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; }

        private ShortenedUrl() { }
        public ShortenedUrl(string fullUrl)
        {
            FullUrl = fullUrl;
            CreatedOn = DateTime.Now;
            ExpiresOn = DateTime.Now + TimeSpan.FromDays(30);
        }
    }
}