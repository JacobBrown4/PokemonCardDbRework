using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class PokemonSetListItem
    {
            public int SetId { get; set; }
            public string NameOfSet { get; set; }
            public string SetAbbr { get; set; }
            public DateTime YearReleased { get; set; }
            public int Rares { get; set; }
            public int Uncommons { get; set; }
            public int Commons { get; set; }
    }
}
