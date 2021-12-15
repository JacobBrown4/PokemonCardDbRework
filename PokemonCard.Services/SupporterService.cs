using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class SupporterService
    {
        private readonly Guid _userID;

        public SupporterService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateSupporter(SupporterCreate model)
        {
            var entity = new Supporter()
            {
                OwnerId = _userID,
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                TypeOfCard = model.TypeOfCard,
                ArtStyle = model.ArtStyle,
                IsHolo = model.IsHolo,
                SupporterAbility = model.SupporterAbility,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Supporters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SupporterListItem> GetSupporters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Supporters.Where(e => e.OwnerId == _userID).Select(e => new SupporterListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public SupporterDetail GetSupporterByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Id == id && e.OwnerId == _userID);
                var set = ctx.PokemonSets.Single(e => e.SetId == entity.SetId);
                return new SupporterDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Set = set,
                    SupporterAbility = entity.SupporterAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity
                };
            }
        }
        public bool UpdateSupporter(SupporterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Name == model.Name && e.OwnerId == _userID);
                entity.Name = model.Name;
                entity.Set = model.Set;
                entity.SupporterAbility = model.SupporterAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;
                entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSupporter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Id == id && e.OwnerId == _userID);
                ctx.Supporters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

