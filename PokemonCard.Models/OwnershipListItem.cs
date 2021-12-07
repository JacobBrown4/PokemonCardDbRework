using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class OwnershipListItem
    {
        public int OwnerID { get; set; }
        public string Owner { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
