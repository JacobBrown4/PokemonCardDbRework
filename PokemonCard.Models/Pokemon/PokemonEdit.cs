using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class PokemonEdit : CardEdit
    {
        [Required]
        public PokemonType PokemonType { get; set; }
        [Required]
        public bool Evolves { get; set; }
        [Required]
        public string Attack1 { get; set; }
        [Required]
        public string Attack2 { get; set; }
    }
}
