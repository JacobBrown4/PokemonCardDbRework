using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class ItemEdit : CardEdit
    {
        [Required]
        public string ItemAbility { get; set; }
    }
}
