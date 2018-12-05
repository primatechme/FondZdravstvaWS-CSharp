using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Lager
{
    [Serializable, XmlRoot(ElementName = "Greske")]
    public class PostLagerResponse : List<LagerResponse>
    {
    }

    [Serializable, XmlType("Zapis")]
    public class LagerResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "ID")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Kljuc")]
        public string Kljuc { get; set; }

        [XmlElement(ElementName = "Zaglavlje")]
        public string Zaglavlje { get; set; }

        [XmlElement(ElementName = "XMLId")]
        public string XMLId { get; set; }

        [XmlElement(ElementName = "Detalji")]
        public List<LagerResponseDetails> Detalji { get; set; }
    }

    [Serializable, XmlType("Detalji")]
    public class LagerResponseDetails
    {
        [XmlElement(ElementName = "RBr")]
        public string RBr { get; set; }

        [XmlElement(ElementName = "Opis")]
        public string Opis { get; set; }
    }
}
