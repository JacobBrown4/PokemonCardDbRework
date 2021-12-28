using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class SetDetail
    {
        public int SetId { get; set; }
        public string NameOfSet { get; set; }
        public string SetAbbr { get; set; }
        public DateTime YearReleased { get; set; }
        public int RareCount { get; set; }
        public int UncommonCount { get; set; }
        public int CommonCount { get; set; }
        public int SetCardsInDb { get; set; }
        public List<CardListItem> Rares { get; set; }
        public List<CardListItem> Uncommons { get; set; }
        public List<CardListItem> Commons { get; set; }
    }
}
