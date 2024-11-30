using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models
{
    public class District
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [MaxLength(DistrictNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DistrictPostalCodeMaxLength)]
        public string PostalCode { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}
