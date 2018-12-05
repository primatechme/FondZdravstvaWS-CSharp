using Primatech.FondZdravstvaWS.Helpers;
using Primatech.FondZdravstvaWS.Models.Lager;
using Primatech.FondZdravstvaWS.Models.Sifarnici;
using Primatech.FondZdravstvaWS.Proxy;
using System.Collections.Generic;

namespace Primatech.FondZdravstvaWS
{
    public class FondZdravstvaWSClient
    {
        private const string URL_SIFARNICI = "https://trust1.fzocg.net:443/wspaZalihe/getSifarnici";
        private const string URL_LAGER = "https://trust1.fzocg.net:443/wspaZalihe/prijemLagera";

        public FondZdravstvaWSConfig Config;

        private SifarniciProxy _sifarniciProxy;
        private LagerProxy _lagerProxy;

        public FondZdravstvaWSClient(FondZdravstvaWSConfig config)
        {
            config.LagerUrl = URL_LAGER;
            config.SifarniciUrl = URL_SIFARNICI;
            Config = config;

            _sifarniciProxy = new SifarniciProxy(Config);
            _lagerProxy = new LagerProxy(Config);
        }

        /// <summary>
        /// Fondov šifrarnik zdravstvenih/apotekarskih ustanova
        /// </summary>
        /// <returns></returns>
        public IList<Ustanova> GetUstanove()
        {
            var xml = _sifarniciProxy.Sifarnici(Config.SifraUstanove, "Ustanova", "");
            var data = SerializationHelper.XmlStringToData<UstanoveResponse>(xml);
            return data;
        }

        /// <summary>
        /// Fondov šifrarnik org.jedinica – apoteka
        /// </summary>
        /// <returns></returns>
        public IList<OrganizacionaJedinica> GetOrganizacioneJedinice()
        {
            var xml = _sifarniciProxy.Sifarnici(Config.SifraUstanove, "OrganizacionaJedinica", "");
            var data = SerializationHelper.XmlStringToData<OrganizacionaJedinicaResponse>(xml);
            return data;
        }

        public IList<JedinicaMjere> GetJediniceMjere()
        {
            var xml = _sifarniciProxy.Sifarnici(Config.SifraUstanove, "JedinicaMjere", "");
            var data = SerializationHelper.XmlStringToData<JedinicaMjereResponse>(xml);
            return data;
        }

        public IList<LijekoviLager> GetLijekoviLager()
        {
            var xml = _sifarniciProxy.Sifarnici(Config.SifraUstanove, "LijekoviLager", "");
            var data = SerializationHelper.XmlStringToData<LijekoviLagerResponse>(xml);
            return data;
        }

        public IList<Proizvodjac> GetProizvodjaci()
        {
            var xml = _sifarniciProxy.Sifarnici(Config.SifraUstanove, "Proizvodjac", "");
            var data = SerializationHelper.XmlStringToData<ProizvodjacResponse>(xml);
            return data;
        }

        public IList<LagerResponse> PostLager(PostLagerRequest model)
        {
            var xml = SerializationHelper.DataToXmlString(model);
            var response = _lagerProxy.getLager(xml);
            var result = SerializationHelper.XmlStringToData<PostLagerResponse>(response);
            return result;
        }
    }
}
