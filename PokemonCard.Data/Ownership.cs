using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Data
{
    public class Ownership
    {
        [Key]
        public int OwnerID { get; set; }
        [Required]
        public Guid Owner { get; set; }

        [Required]
        public int CardID { get; set; }// see above 
        
        public virtual Card Card { get; set; }// see above 

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
