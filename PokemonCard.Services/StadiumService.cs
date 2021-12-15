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
                OwnerId = _userID,
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                ArtStyle = model.ArtStyle,
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
                var query = ctx.Stadiums.Where(e => e.OwnerId == _userID).Select(e => new StadiumListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public StadiumDetail GetStadiumByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Id == id && e.OwnerId == _userID);
                var set = ctx.PokemonSets.Single(e => e.SetId == entity.SetId);
                return new StadiumDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Set = set,
                    StadiumAbility = entity.StadiumAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity
                };
            }
        }
        public bool UpdateStadium(StadiumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Name == model.Name && e.OwnerId == _userID);
                entity.Name = model.Name;
                entity.Set = model.Set;
                entity.StadiumAbility = model.StadiumAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;
                entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStadium(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stadiums.Single(e => e.Id == id && e.OwnerId == _userID);
                ctx.Stadiums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

