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
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey("Card")]
        [Required]
        public int CardID { get; set; }// see above 
        
        public virtual Card Card { get; set; }// see above 
        public bool IsInDeck { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
