using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Sifarnici
{
    [Serializable, XmlRoot(ElementName = "SifarnikProizvodjac")]
    public class ProizvodjacResponse : List<Proizvodjac>
    {
    }

    [Serializable, XmlType("Proizvodjac")]
    public class Proizvodjac
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Datum { get; set; }
    }
}
