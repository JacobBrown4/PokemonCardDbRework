using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class SetEdit
    {
        [Required]
        public int SetId { get; set; }
        [Required]
        public string NameOfSet { get; set; }
        [Required]
        public string SetAbbr { get; set; }
        [Required]
        public DateTime YearReleased { get; set; }
        [Required]
        public int RareCount { get; set; }
        [Required]
        public int UncommonCount { get; set; }
        [Required]
        public int CommonCount { get; set; }
    }
}
