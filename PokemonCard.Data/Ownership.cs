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
        
       
        [Required] //foreign key will go here probably 
        public int CardID { get; set; }// see above 
        
        public virtual Card Card { get; set; }// see above 
        [Required]
        public Guid Owner { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
