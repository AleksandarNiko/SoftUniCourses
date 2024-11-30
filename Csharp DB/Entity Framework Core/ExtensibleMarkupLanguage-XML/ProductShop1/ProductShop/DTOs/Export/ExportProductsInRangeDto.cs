using System.Xml.Serialization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ExportProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }


        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string? BuyerFullName { get; set; }
    }
}
