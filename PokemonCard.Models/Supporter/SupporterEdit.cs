using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class SupporterEdit : CardEdit
    {
        [Required]
        public string SupporterAbility { get; set; }
    }
}
