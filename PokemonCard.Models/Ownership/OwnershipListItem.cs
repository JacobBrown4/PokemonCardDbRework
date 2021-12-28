using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipListItem
    {
        public int OwnershipId { get; set; }
        public int CardId { get; set; }
        public bool IsInDeck { get; set; }
    }
}
