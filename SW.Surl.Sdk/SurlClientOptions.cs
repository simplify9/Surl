using SW.HttpExtensions;

namespace SW.Surl.Sdk
{
    public class SurlClientOptions : ApiClientOptionsBase
    {
        public override string ConfigurationSection { get; } = "SurlClient";
    }
}