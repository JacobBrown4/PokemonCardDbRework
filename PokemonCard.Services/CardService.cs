
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

        public CardDetail GetCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == id && e.OwnerId == _userId);
                    return
                        new CardDetail
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            Set = entity.Set,
                            TypeOfCard = entity.TypeOfCard,
                            IsHolo = entity.IsHolo,
                            ArtStyle = entity.ArtStyle,
                            Rarity = entity.Rarity
                        };
            }
        }
        public bool UpdateCard (CardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.Name == model.Name && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.Set = model.Set;
                entity.TypeOfCard = model.TypeOfCard;
                entity.IsHolo = model.IsHolo;
                entity.ArtStyle = model.ArtStyle;
                entity.Rarity = model.Rarity;
                entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == id && e.OwnerId == _userId);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
