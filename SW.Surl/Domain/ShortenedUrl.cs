using System;
using SW.PrimitiveTypes;

namespace SW.Surl.Domain
{
    public class ShortenedUrl : BaseEntity<string>, ICreationAudited
    {
        public string FullUrl { get; private set; }
        public DateTime ExpiresOn { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        

        private ShortenedUrl() { }
        public ShortenedUrl(string fullUrl, int daysToExpire = 30)
        {
            FullUrl = fullUrl;
            CreatedOn = DateTime.Now;
            ExpiresOn = DateTime.Now + TimeSpan.FromDays(daysToExpire);
        }

    }
}