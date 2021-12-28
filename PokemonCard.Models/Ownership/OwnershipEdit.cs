using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipEdit
    {
        [Required]
        public int OwnershipId { get; set; }
        [Required]
        public int CardID { get; set; }
        [Required]
        public bool IsInDeck { get; set; }
    }
}
