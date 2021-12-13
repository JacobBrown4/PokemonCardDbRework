using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class OwnershipService
    {
        private readonly Guid _ownerID;
        public OwnershipService(Guid ownerID)
        {
            _ownerID = ownerID;
        }
        public bool CreateOwner(OwnershipCreate model)
        {
            var entity = new Ownership()
            {
                Owner =_ownerID,
                
                CardID = model.CardID,
                Card = model.Card,
                CreatedUTC = DateTimeOffset.Now
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Owners.Add(entity);
                return ctx.SaveChanges()==1;
            }
        }
        public IEnumerable<OwnershipListItem> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Owners
                                .Where(e => e.Owner == _ownerID)
                                .Select(e => new OwnershipListItem
                                {
                                    OwnerID= e.OwnerID,
                                    CreatedUTC = e.CreatedUTC
                                });
                return query.ToArray();
            }
        }
        public OwnershipDetail GetOwnerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Owners.Single(e => e.OwnerID == id && e.Owner == _ownerID);
                return new OwnershipDetail
                {
                    OwnerID = entity.OwnerID,
                    
                    CardName = entity.Card.Name,
                    CardID = entity.CardID,
                    CardRarity = entity.Card.Rarity,
                    SetName =entity.Card.Set.NameOfSet, //goes into the card then the set and pull the name of the set. (can pull all kinds of stuff with the Set
                    SetAbv = entity.Card.Set.SetAbbr,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC

                };
            }
        }
        public bool UpdateOwner(OwnershipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Owners.Single(e => e.OwnerID == model.OwnderID && e.Owner == _ownerID);

                entity.OwnerID = model.OwnderID;
                
                entity.CardID = model.CardID;
                entity.Card = model.Card;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOwner (int ownerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Owners.Single(e => e.OwnerID == ownerID && e.Owner == _ownerID);
                ctx.Owners.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
