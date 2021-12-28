using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class StadiumService
    {
        private readonly Guid _userID;

        public StadiumService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateStadium(StadiumCreate model)
        {
            var entity = new Stadium()
            {
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                ArtStyle = model.ArtStyle,
                TypeOfCard = CardType.Stadium,
                IsHolo = model.IsHolo,
                StadiumAbility = model.StadiumAbility,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stadiums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StadiumListItem> GetStadiums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Stadiums.Select(e => new StadiumListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public IEnumerable<StadiumListItem> GetStadiumsByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stadiums.Where(x => x.Rarity == rarity)
                        .Select(
                            e =>
                                new StadiumListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public StadiumDetail GetStadiumByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Id == id);
                return new StadiumDetail
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
                    StadiumAbility = entity.StadiumAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity,
                    TypeOfCard = entity.TypeOfCard,
                };
            }
        }
        public bool UpdateStadium(StadiumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Name == model.Name);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.StadiumAbility = model.StadiumAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStadium(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Id == id);
                ctx.Stadiums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

