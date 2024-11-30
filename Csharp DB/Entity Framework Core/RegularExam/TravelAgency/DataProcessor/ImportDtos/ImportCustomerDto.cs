using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TravelAgency.Data.Models;
using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType(nameof(Customer))]
    public class ImportCustomerDto
    {
        [XmlAttribute("phoneNumber")]
        [RegularExpression(CustomerPhoneNumberRegEx)]
        [StringLength(13)]
        [Required]
        public string PhoneNumber { get; set; } = null!;

        [XmlElement(nameof(FullName))]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        [Required]
        public string FullName { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        [Required]
        public string Email { get; set; } = null!;
    }
}
