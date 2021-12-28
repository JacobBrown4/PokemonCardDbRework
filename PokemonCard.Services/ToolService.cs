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
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                TypeOfCard = CardType.Tool,
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
                var query = ctx.Tools.Select(e => new ToolListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public IEnumerable<ToolListItem> GetToolsByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tools.Where(x => x.Rarity == rarity)
                        .Select(
                            e =>
                                new ToolListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public ToolDetail GetToolByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Id == id);
                
                return new ToolDetail
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
                    ToolAbility = entity.ToolAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity,
                    TypeOfCard = entity.TypeOfCard,
                };
            }
        }
        public bool UpdateTool(ToolEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Name == model.Name);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.ToolAbility = model.ToolAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTool(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tools.Single(e => e.Id == id);
                ctx.Tools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

