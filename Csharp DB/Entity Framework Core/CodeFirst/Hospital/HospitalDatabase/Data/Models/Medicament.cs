using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<PatientMedicament> Prescriptions { get; set; }=new List<PatientMedicament>();

    }
}
