﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public class PokemonSet
    {
        [Key]
        public int SetId { get; set; } // Order that the set was released in
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
        public virtual List<Card> Cards { get; set; }

    }
}
