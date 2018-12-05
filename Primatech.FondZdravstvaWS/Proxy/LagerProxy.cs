using System;
using System.Net;

namespace Primatech.FondZdravstvaWS.Proxy
{
    public class LagerProxy : prijemLagera
    {
        private FondZdravstvaWSConfig _config;

        public LagerProxy(FondZdravstvaWSConfig config)
        {
            _config = config;
            Url = config.LagerUrl;
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
            _config.AddAuthHeader(request);
            return request;
        }
    }
}
