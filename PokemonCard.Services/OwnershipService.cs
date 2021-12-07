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
        private readonly Guid _ownderID;
        public OwnershipService(Guid ownerID)
        {
            _ownderID = ownerID;
        }
        public bool CreateOwner(OwnershipCreate model)
        {
            var entity = new Ownership()
            {
                ID = model.ID,
                SetID = model.SetID,
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
                                .Where(e => e.Owner == _ownderID)
                                .Select(e => new OwnershipListItem
                                {
                                    //OwnerID = e.ID,
                                    //Owner = e.Owner,
                                    CreatedUTC = e.CreatedUTC
                                });
                return query.ToArray();
            }
        }
    }
}
