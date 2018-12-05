using System;
using System.Text;

namespace Primatech.FondZdravstvaWS
{
    public class FondZdravstvaWSConfig
    {
        public string SifraUstanove { get; set; }
        public string OrgJedinicaId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LagerUrl { get; set; }
        public string SifarniciUrl { get; set; }

        public void AddAuthHeader(System.Net.HttpWebRequest request)
        {
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Username + ":" + Password));
            request.Headers.Add("Authorization", "Basic " + encoded);
        }
    }
}