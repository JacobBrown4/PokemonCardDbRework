using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class SetService
    {
        private readonly Guid _userId;

        public SetService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSet(SetCreate model)
        {
            var entity =
                new PokemonSet()
                {
                    NameOfSet = model.NameOfSet,
                    SetAbbr = model.SetAbbr,
                    YearReleased = model.YearReleased,
                    RareCount = model.RareCount,
                    UncommonCount = model.UncommonCount,
                    CommonCount = model.CommonCount
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PokemonSets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PokemonSetListItem> GetPokemonSets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PokemonSets
                        .Select(
                            e =>
                                new PokemonSetListItem
                                {
                                    SetId = e.SetId,
                                    NameOfSet = e.NameOfSet,
                                    SetAbbr = e.SetAbbr,
                                    YearReleased = e.YearReleased,
                                    TotalCards = e.RareCount + e.UncommonCount + e.CommonCount

                                }
        );

                return query.ToArray();
            }
        }
        public SetDetail GetSetBySetId(int setId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonSets
                        .Single(e => e.SetId == setId);
                return
                    new SetDetail
                    {
                        SetId = entity.SetId,
                        NameOfSet = entity.NameOfSet,
                        SetAbbr = entity.SetAbbr,
                        YearReleased = entity.YearReleased,
                        RareCount = entity.RareCount,
                        UncommonCount = entity.UncommonCount,
                        CommonCount = entity.CommonCount,
                        SetCardsInDb = entity.Cards.Count(),
                        Rares = entity.Cards.Where(c => c.Rarity == Rarity.Rare).Select(x => new CardListItem()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CardType = x.TypeOfCard
                        }).ToList(),
                        Uncommons = entity.Cards.Where(c => c.Rarity == Rarity.Uncommon).Select(x => new CardListItem()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CardType = x.TypeOfCard
                        }).ToList(),
                        Commons = entity.Cards.Where(c => c.Rarity == Rarity.Common).Select(x => new CardListItem()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            CardType = x.TypeOfCard
                        }).ToList()
                    };
            }
        }
        public bool UpdateSet(SetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PokemonSets
                        .Single(e => e.SetId == model.SetId);

                entity.NameOfSet = model.NameOfSet;
                entity.SetAbbr = model.SetAbbr;
                entity.YearReleased = model.YearReleased;
                entity.RareCount = model.RareCount;
                entity.UncommonCount = model.UncommonCount;
                entity.CommonCount = model.CommonCount;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteSet(int setId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PokemonSets
                    .Single(e => e.SetId == setId);

                ctx.PokemonSets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
