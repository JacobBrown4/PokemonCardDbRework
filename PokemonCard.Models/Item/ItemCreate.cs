using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class ItemCreate : CardCreate
    {
        [Required]
        public string ItemAbility { get; set; }
    }
}
