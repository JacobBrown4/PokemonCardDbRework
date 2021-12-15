using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public enum PokemonType
    {
        Water = 1,
        Grass,
        ColorLess,
        Electric,
        Dark,
        Fighting,
        Psychic,
        Fire,
        Metal,
        Dragon,
        Fairy
    }
    public class Pokemon : Card
    {
        public PokemonType PokemonType { get; set; }
        public bool Evolves { get; set; }
        public string Attack1 { get; set; }
        public string Attack2 { get; set; }

    }
}
