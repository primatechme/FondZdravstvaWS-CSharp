using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Sifarnici
{
    [Serializable, XmlRoot(ElementName = "SifarnikUstanova")]
    public class UstanoveResponse : List<Ustanova>
    {
    }

    [Serializable, XmlType("Ustanova")]
    public class Ustanova
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Datum { get; set; }
        public int Status { get; set; }
    }
}
