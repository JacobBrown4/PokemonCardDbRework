using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class ToolCreate : CardCreate
    {
        [Required]
        public string ToolAbility { get; set; }
    }
}
