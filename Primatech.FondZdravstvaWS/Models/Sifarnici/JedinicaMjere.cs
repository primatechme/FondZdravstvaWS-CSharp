using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Sifarnici
{
    [Serializable, XmlRoot(ElementName = "SifarnikJedinicaMjere")]
    public class JedinicaMjereResponse : List<JedinicaMjere>
    {
    }

    [Serializable, XmlType("JedinicaMjere")]
    public class JedinicaMjere
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Datum { get; set; }
    }
}