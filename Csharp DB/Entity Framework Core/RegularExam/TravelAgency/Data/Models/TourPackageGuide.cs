using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [Required]
        public  int TourPackageId { get; set; }
        public TourPackage TourPackage { get; set; }

        [Required]
        public  int GuideId { get; set; }
        public  Guide Guide { get; set; }
    }
}
