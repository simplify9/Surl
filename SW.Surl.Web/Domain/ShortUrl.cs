using System;
using SW.PrimitiveTypes;

namespace SW.Surl.Domain
{
    class ShortUrl : BaseEntity<string>, ICreationAudited
    {
        public string FullUrl { get; private set; }
        //public DateTime ExpiresOn { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }


        private ShortUrl()
        {
        }

        public ShortUrl(string id, string fullUrl, int daysToExpire = 30)
        {
            Id = id;
            FullUrl = fullUrl;
            //CreatedOn = DateTime.Now;
            //ExpiresOn = DateTime.Now + TimeSpan.FromDays(daysToExpire);
        }

    }
}