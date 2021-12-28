using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class ItemService
    {
        private readonly Guid _userID;

        public ItemService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity = new Item()
            {

                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,                
                ArtStyle = model.ArtStyle,
                TypeOfCard = CardType.Item,
                IsHolo = model.IsHolo,
                ItemAbility = model.ItemAbility,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Items.Select(e => new ItemListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public IEnumerable<ItemListItem> GetItemsByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items.Where(x => x.Rarity == rarity)
                        .Select(
                            e =>
                                new ItemListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public ItemDetail GetItemByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Id == id);
                
                return new ItemDetail
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
                    ArtStyle = entity.ArtStyle,
                    ItemAbility = entity.ItemAbility,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity,
                    TypeOfCard = entity.TypeOfCard
                };
            }
        }
        public bool UpdateItem (ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Name == model.Name);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.ItemAbility = model.ItemAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Id == id);
                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
