using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boardgames.Data.DataConstraints;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardGameNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public  double Rating { get; set; }

        [Required]
        public  int YearPublished { get; set; }

        [Required]
        public  CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;

        [Required]
        public  int CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public virtual Creator Creator { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } 
            = new HashSet<BoardgameSeller>();
    }
}
