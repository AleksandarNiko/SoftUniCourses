using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models
{
    public class Property
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        public int Area { get; set; }

        [MaxLength(PropertyDetailsMaxLength)]
        public  string? Details { get; set; }

        [Required]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfAcquisition  { get; set; }

        [Required]
        public  int DistrictId { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; } = null!;

        public  ICollection<PropertyCitizen> PropertiesCitizens  { get; set; }=new HashSet<PropertyCitizen>();
    }
}
