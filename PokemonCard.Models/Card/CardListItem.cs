using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PokemonCard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Models
{
    public class CardListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CardType CardType { get; set; }
    }
}
