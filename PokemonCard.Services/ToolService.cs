using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class ToolService
    {
        private readonly Guid _userID;

        public ToolService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateTool(ToolCreate model)
        {
            var entity = new Tool()
            {
                OwnerId = _userID,
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                ArtStyle = model.ArtStyle,
                IsHolo = model.IsHolo,
                ToolAbility = model.ToolAbility,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ToolListItem> GetTools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tools.Where(e => e.OwnerId == _userID).Select(e => new ToolListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public ToolDetail GetToolByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Id == id && e.OwnerId == _userID);
                var set = ctx.PokemonSets.Single(e => e.SetId == entity.SetId);
                return new ToolDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Set = set,
                    ToolAbility = entity.ToolAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity
                };
            }
        }
        public bool UpdateTool(ToolEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Name == model.Name && e.OwnerId == _userID);
                entity.Name = model.Name;
                entity.Set = model.Set;
                entity.ToolAbility = model.ToolAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;
                entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTool(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Id == id && e.OwnerId == _userID);
                ctx.Tools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

