using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipDetail
    {
        public int OwnershipId { get; set; }
        public bool IsInDeck { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        public CardListItem Card { get; set; }
    }
}
