using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    
    public enum ArtStyle
    {
        Holo,
        Reverse_Holo,
        Full_Art,
        Half_Art,
        Normal
    }

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        //[Required]
        [ForeignKey("Set")]
        public int SetId { get; set; }

        
        public virtual PokemonSet Set { get; set; }

        [Required]
        public CardType TypeOfCard { get; set; }

        [Required]
        public bool IsHolo { get; set; }

        [Required]
        public ArtStyle ArtStyle { get; set; }

        [Required]
        public Rarity Rarity { get; set; }

        public Guid OwnerId { get; set; }
    }
}
