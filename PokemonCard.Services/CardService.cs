
using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class CardService
    {
        private readonly Guid _userId;

        public CardService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCard(CardCreate model)
        {
            var entity =
                new Card()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Set = model.Set,
                    TypeOfCard = model.TypeOfCard,
                    Rarity = model.Rarity,
                    ArtStyle = model.ArtStyle
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        } 
        
        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

    }
}
