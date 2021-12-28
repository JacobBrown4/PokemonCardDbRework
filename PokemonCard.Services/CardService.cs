
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
        //Unused after split classes
        //public bool CreateCard(CardCreate model)
        //{
        //    var entity =
        //        new Card()
        //        {
        //            Name = model.Name,
        //            SetId = model.SetId,
        //            Rarity = model.Rarity,
        //            ArtStyle = model.ArtStyle
        //        };

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.Cards.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //} 
        
        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType= e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<CardListItem> GetCardsByName()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards.OrderBy(x => x.Name)
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard

                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<CardListItem> GetHolos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards.Where(x => x.IsHolo == true)
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<CardListItem> GetCardsByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards.Where(x => x.Rarity == rarity)
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType= e.TypeOfCard
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
                        .Single(e => e.Id == id );
                    return
                        new CardDetail
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            Set = new PokemonSetListItem()
                            {
                                SetId = entity.SetId,
                                NameOfSet = entity.Set.NameOfSet,
                                SetAbbr = entity.Set.SetAbbr,
                                YearReleased = entity.Set.YearReleased,
                                TotalCards = entity.Set.UncommonCount + entity.Set.RareCount + entity.Set.CommonCount,
                            },
                            TypeOfCard = entity.TypeOfCard,
                            IsHolo = entity.IsHolo,
                            ArtStyle = entity.ArtStyle,
                            Rarity = entity.Rarity
                        };
            }
        }
        //Unused
        //public bool UpdateCard (CardEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Cards.Single(e => e.Id == model.Id );
        //        var set =
        //            ctx.PokemonSets.Single(e => e.SetId == entity.SetId);

        //        entity.Name = model.Name;
        //        entity.SetId = model.SetId;
        //        entity.Set = set;
        //        entity.TypeOfCard = model.TypeOfCard;
        //        entity.IsHolo = model.IsHolo;
        //        entity.ArtStyle = model.ArtStyle;
        //        entity.Rarity = model.Rarity;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        public bool DeleteCard(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == id);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
