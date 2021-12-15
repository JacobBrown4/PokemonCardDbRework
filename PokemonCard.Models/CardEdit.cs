using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class CardEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SetId { get; set; }
        public PokemonSet Set { get; set; }
        public CardType TypeOfCard { get; set; }
        public bool IsHolo { get; set; }
        public ArtStyle ArtStyle { get; set; }
        public Rarity Rarity { get; set; }
        public Guid OwnerId { get; set; }
    }
}
