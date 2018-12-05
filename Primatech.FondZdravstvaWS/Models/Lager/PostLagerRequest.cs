using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Lager
{
    [Serializable, XmlRoot(ElementName = "PodaciOLageru")]
    public class PostLagerRequest : List<Lager>
    {
    }

    [Serializable, XmlType("Lager")]
    public class Lager
    {
        /// <summary>
        /// Sifra apoteke (iz sifarnika), VARCHAR(6)
        /// </summary>
        [XmlElement(ElementName = "Apot")]
        public string ApotekaId { get; set; }

        /// <summary>
        /// Sifra lijeka (iz sifarnika), VARCHAR(15)
        /// </summary>
        [XmlElement(ElementName = "SifraLijFond")]
        public string SifraFond { get; set; }

        /// <summary>
        /// Sifra lijeka interna, NVARCHAR(4000)
        /// </summary>
        [XmlElement(ElementName = "SifraLij")]
        public string Sifra { get; set; }

        /// <summary>
        /// Naziv lijeka INTERNI, NVARCHAR(4000)
        /// </summary>
        [XmlElement(ElementName = "NazLij")]
        public string Naziv { get; set; }

        /// <summary>
        /// Jedinica mjere (iz sifarnika),  NVARCHAR(10). Ukoliko nije ista JM kao u fondu dolazi do serverske greske.
        /// </summary>
        [XmlElement(ElementName = "JMLijeka")]
        public string JMFond { get; set; }

        /// <summary>
        /// Stanje na lageru, 16 char 
        /// </summary>
        [XmlElement(ElementName = "Kol")]
        public int Kolicina { get; set; }

        /// <summary>
        /// Datum forimaranja lagera dd.MM.yyyy
        /// </summary>
        [XmlElement(ElementName = "Datum")]
        public string Datum { get; set; }

        public void SetDatum(DateTime date)
        {
            Datum = string.Format("{0:dd.MM.yyyy}", date);
        }
    }
}
