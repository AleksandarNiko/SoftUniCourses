using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportPropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [MinLength(PropertyIdentifierMinLength)]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        [Range(0,int.MaxValue)]
        public int Area { get; set; }

        [XmlElement("Details")]
        [MinLength(PropertyDetailsMinLength)]
        [MaxLength(PropertyDetailsMaxLength)]
        public string Details { get; set; }

        [XmlElement("Address")]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        public DateTime DateOfAcquisition { get; set; }
    }
}
