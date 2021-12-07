using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipCreate
    {
        [Required]
        public int ID { get; set; }
        public int SetID { get; set; }
        public int CardID { get; set; }
        public Card Card { get; set; }


    }
}
