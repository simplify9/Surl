using System;
using SW.PrimitiveTypes;

namespace SW.Surl.Domain
{
    public class ShortenedUrl : BaseEntity<string> 
    {
        public string FullUrl { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; }
    }
}