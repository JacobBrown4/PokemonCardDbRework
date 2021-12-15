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

                OwnerId = _userID,
                Name = model.Name,
                SetId = model.SetId,
                Rarity = model.Rarity,                
                ArtStyle = model.ArtStyle,
                TypeOfCard = model.TypeOfCard,
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
                var query = ctx.Items.Where(e => e.OwnerId == _userID).Select(e => new ItemListItem { Id = e.Id, Name = e.Name });
                return query.ToArray();
            }
        }
        public ItemDetail GetItemByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Id == id && e.OwnerId == _userID);
                var set = ctx.PokemonSets.Single(e => e.SetId == entity.SetId);
                return new ItemDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Set = set,
                    ArtStyle = entity.ArtStyle,
                    ItemAbility = entity.ItemAbility,
                    IsHolo = entity.IsHolo,
                    Rarity = entity.Rarity
                };
            }
        }
        public bool UpdateItem (ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Name == model.Name && e.OwnerId == _userID);
                entity.Name = model.Name;
                entity.Set = model.Set;
                entity.ItemAbility = model.ItemAbility;
                entity.ArtStyle = model.ArtStyle;
                entity.IsHolo = model.IsHolo;
                entity.Rarity = model.Rarity;
                entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Items.Single(e => e.Id == id && e.OwnerId == _userID);
                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
