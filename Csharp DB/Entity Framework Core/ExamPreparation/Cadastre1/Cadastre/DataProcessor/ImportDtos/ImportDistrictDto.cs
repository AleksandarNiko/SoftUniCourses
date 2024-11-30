using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
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
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [XmlAttribute("Region")]
        public string Region { get; set; } = null!;

        [Required]
        [XmlElement("Name")]
        [MinLength(DistrictNameMinLength)]
        [MaxLength(DistrictNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("PostalCode")]
        [MinLength(DistrictPostalCodeMinLength)]
        [MaxLength(DistrictPostalCodeMaxLength)]
        [RegularExpression(DistrictPostalCodeRegEx)]
        public string PostalCode { get; set; } = null!;

        [XmlArray(nameof(Properties))]
        [XmlArrayItem(nameof(Property))]
        public ImportPropertyDto[] Properties { get; set; } = null!;
    }
}
