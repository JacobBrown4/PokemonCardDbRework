using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipEdit
    {
        public int OwnerID { get; set; }
        public int SetID { get; set; }
        public int CardID { get; set; }
        public Card Card { get; set; }

    }
}
