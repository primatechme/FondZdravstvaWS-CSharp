using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Primatech.FondZdravstvaWS.Models.Sifarnici
{
    [Serializable, XmlRoot(ElementName = "SifarnikOrganizacionaJedinica")]
    public class OrganizacionaJedinicaResponse : List<OrganizacionaJedinica>
    {
    }

    [Serializable, XmlType("OrganizacionaJedinica")]
    public class OrganizacionaJedinica
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Datum { get; set; }
    }
}
