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
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,
                TypeOfCard = CardType.Supporter,
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
                var query = ctx.Supporters.Select(e => new SupporterListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public IEnumerable<SupporterListItem> GetSupportersByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Supporters.Where(x => x.Rarity == rarity)
                        .Select(
                            e =>
                                new SupporterListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public SupporterDetail GetSupporterByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Id == id);
                
                return new SupporterDetail
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
                    SupporterAbility = entity.SupporterAbility,
                    ArtStyle = entity.ArtStyle,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity,
                    TypeOfCard = entity.TypeOfCard
                };
            }
        }
        public bool UpdateSupporter(SupporterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Name == model.Name);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.SupporterAbility = model.SupporterAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSupporter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Supporters.Single(e => e.Id == id);
                ctx.Supporters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

