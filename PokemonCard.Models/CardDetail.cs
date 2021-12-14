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
    public class CardDetail
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public PokemonSet Set { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType TypeOfCard { get; set; }
        public bool IsHolo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ArtStyle ArtStyle { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity Rarity { get; set; }
    }
}
