using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    //Come back to this. Might need to add the enums in the this class instead of pulling from the data library.
    public class CardCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        public Set Set { get; set; }
        public CardType TypeOfCard { get; set; }
        public Rarity Rarity {get; set;}
        public ArtStyle ArtStyle { get; set; }
    }
}
