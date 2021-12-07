using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public class Ownership
    {
        
        public int ID { get; set; }
        [Required]
        public int SetID { get; set; }
        [Required]
        public int CardID { get; set; }
        [Required]
        public Card Card { get; set; }
        [Key]
        public Guid Owner { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
