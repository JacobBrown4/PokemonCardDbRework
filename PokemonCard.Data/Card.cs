using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public enum Rarity
    {
        Common = 1,
        Uncommon,
        Rare,
        Promo,
        Holo_Rare,
        Ultra_Rare,
        Secret_Rare,
        Shiny_Holo_Rare,
        Prisim_Rare,
        Rare_BREAK,
        Classic_Collection,
        Rare_Ace,
        Amazing_Rare
    }

    public enum CardType
    {
        Pokemon = 1,
        Tool,
        Stadium,
        Item,
        Supporter,
        Energy
    }

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SetId { get; set; }

        [Required]
        public Set Set { get; set; }

        [Required]
        public Rarity Rarity { get; set; }

        [Required]
        public bool IsHolo { get; set; }

        [Required]
        public CardType TypeOfCard { get; set; }
    }
}
