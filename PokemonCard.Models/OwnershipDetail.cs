using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipDetail
    {
        public int OwnerID { get; set; }
       
        public int CardID { get; set; }
        public Card Card { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
        public string CardName { get; set; }
        public string SetName { get; set; }
        public string SetAbv { get; set; }
        public Rarity CardRarity { get; set; }
    }
}
