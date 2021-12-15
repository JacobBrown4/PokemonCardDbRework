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
                    Rares = model.Rares,
                    Uncommons = model.Uncommons,
                    Commons = model.Commons
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
                                    Rares = e.Rares,
                                    Uncommons = e.Uncommons,
                                    Commons = e.Commons

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
                        Rares = entity.Rares,
                        Uncommons = entity.Uncommons,
                        Commons = entity.Commons
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
                entity.Rares = model.Rares;
                entity.Uncommons = model.Uncommons;
                entity.Commons = model.Uncommons;

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
