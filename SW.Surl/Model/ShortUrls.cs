using System;

namespace SW.Surl.Model
{
    public class CreateShortUrl
    {
        public string FullUrl { get; set; }
    }

    public class GetShortUrl
    {
        public string FullUrl { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}