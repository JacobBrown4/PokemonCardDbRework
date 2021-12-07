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
        
        public int OwnerID { get; set; }
        [Required]
        public int SetID { get; set; } //do I need these? will they come from Set and Card already? 
        [Required]
        public int CardID { get; set; }// see above 
        [Required]
        public Card Card { get; set; }// see above 
        [Key]
        public Guid Owner { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
