using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models.Ownership
{
    public class DeckDetail
    {
        public int TotalCardCount { get; set; }
        public List<PokemonDetail> PokemonDetails { get; set; }
        public List<ItemDetail> ItemDetails { get; set; }
        public List<StadiumDetail> StadiumDetails { get; set; }
        public List<SupporterDetail> SupporterDetails { get; set; }
        public List<ToolDetail> ToolDetails { get; set; }
    }
}
