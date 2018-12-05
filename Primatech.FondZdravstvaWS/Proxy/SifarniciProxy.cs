using System;
using System.Net;

namespace Primatech.FondZdravstvaWS.Proxy
{
    public class SifarniciProxy : getSifarnici
    {
        private FondZdravstvaWSConfig _config;

        public SifarniciProxy(FondZdravstvaWSConfig config)
        {
            Url = config.SifarniciUrl;
            _config = config;
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
            _config.AddAuthHeader(request);
            return request;
        }
    }
}
