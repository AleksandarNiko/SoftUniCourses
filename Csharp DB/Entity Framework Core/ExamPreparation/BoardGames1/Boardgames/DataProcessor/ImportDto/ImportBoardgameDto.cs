using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Boardgames.Data.DataConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(BoardGameNameMinLength)]
        [MaxLength(BoardGameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Range(BoardGameMinRatingValue, BoardGameMaxRatingValue)]
        public  double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(BoardGameYearPublishedMinValue, BoardGameYearPublishedMaxValue)]
        public  int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(0,4)]
        public  int CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
