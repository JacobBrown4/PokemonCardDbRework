using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class CardCreate
    {
        
        [MaxLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
        [Required]
        public int SetId { get; set; }
        [Required]
        public bool IsHolo { get; set; }
        [Required]
        public Rarity Rarity {get; set;}
        [Required]
        public ArtStyle ArtStyle { get; set; }
    }
}
