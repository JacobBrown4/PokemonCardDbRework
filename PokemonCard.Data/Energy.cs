using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public enum EnergyType
    {
        Water=1,
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
    public class Energy
    {
        public EnergyType EnergyType { get; set; }
    }
}
