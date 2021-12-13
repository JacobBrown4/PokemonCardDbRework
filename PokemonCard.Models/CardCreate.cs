﻿using PokemonCard.Data;
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
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
        public PokemonSet Set { get; set; }
        public CardType TypeOfCard { get; set; }
        public Rarity Rarity {get; set;}
        public ArtStyle ArtStyle { get; set; }
        public bool IsHolo { get; set; }
    }
}
