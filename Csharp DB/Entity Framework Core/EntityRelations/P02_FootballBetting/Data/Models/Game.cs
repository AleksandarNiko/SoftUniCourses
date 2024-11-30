using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Bets = new HashSet<Bet>();
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int GameId { get; set; }
       
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;

        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; } = null!;


        public byte HomeTeamGoals { get; set; }
        public byte AwayTeamGoals { get;set; }

        public DateTime DateTime { get; set; }

        public decimal HomeTeamBetRate { get; set; }
        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        [MaxLength(ValidationConstants.GameResultMaxLength)]
        public string Result { get; set; }
      
        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
