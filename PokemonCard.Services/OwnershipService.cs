using PokemonCard.Data;
using PokemonCard.Models;
using PokemonCard.Models.Ownership;
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
                OwnerId = _ownerID,
                CardID = model.CardID,
                IsInDeck = model.IsInDeck,
                CreatedUTC = DateTimeOffset.Now

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ownerships.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OwnershipListItem> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID)
                                .Select(e => new OwnershipListItem
                                {
                                    OwnershipId = e.Id,
                                    CardId = e.CardID,
                                    IsInDeck = e.IsInDeck,
                                });
                return query.ToArray();
            }
        }
        public IEnumerable<CardListItem> GetDeck()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true)
                                .Select(e => new CardListItem
                                {
                                    Id = e.Card.Id,
                                    Name = e.Card.Name,
                                    CardType = e.Card.TypeOfCard
                                });
                return query.ToArray();
            }
        }
        public DeckDetail GetDeckDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokeCards = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true && o.Card.TypeOfCard == CardType.Pokemon)
                    .Select(e => e.Card)
                    .OfType<Pokemon>()
                                .Select(e => new PokemonDetail
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    TypeOfCard = e.TypeOfCard,
                                    Set = new PokemonSetListItem()
                                    {
                                        SetId = e.SetId,
                                        NameOfSet = e.Set.NameOfSet,
                                        SetAbbr = e.Set.SetAbbr,
                                        YearReleased = e.Set.YearReleased,
                                        TotalCards = e.Set.UncommonCount + e.Set.RareCount + e.Set.CommonCount,
                                    },
                                    IsHolo = e.IsHolo,
                                    ArtStyle = e.ArtStyle,
                                    Rarity = e.Rarity,
                                    PokemonType = e.PokemonType,
                                    Evolves = e.Evolves,
                                    Attack1 = e.Attack1,
                                    Attack2 = e.Attack2
                                }).ToList();
                var itemCards = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true && o.Card.TypeOfCard == CardType.Item)
                    .Select(e => e.Card)
                    .OfType<Item>()
                                .Select(e => new ItemDetail
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    TypeOfCard = e.TypeOfCard,
                                    Set = new PokemonSetListItem()
                                    {
                                        SetId = e.SetId,
                                        NameOfSet = e.Set.NameOfSet,
                                        SetAbbr = e.Set.SetAbbr,
                                        YearReleased = e.Set.YearReleased,
                                        TotalCards = e.Set.UncommonCount + e.Set.RareCount + e.Set.CommonCount,
                                    },
                                    IsHolo = e.IsHolo,
                                    ArtStyle = e.ArtStyle,
                                    Rarity = e.Rarity,
                                    ItemAbility = e.ItemAbility,
                                }).ToList();
                var stadiumCards = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true && o.Card.TypeOfCard == CardType.Stadium)
                    .Select(e => e.Card)
                    .OfType<Stadium>()
                                .Select(e => new StadiumDetail
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    TypeOfCard = e.TypeOfCard,
                                    Set = new PokemonSetListItem()
                                    {
                                        SetId = e.SetId,
                                        NameOfSet = e.Set.NameOfSet,
                                        SetAbbr = e.Set.SetAbbr,
                                        YearReleased = e.Set.YearReleased,
                                        TotalCards = e.Set.UncommonCount + e.Set.RareCount + e.Set.CommonCount,
                                    },
                                    IsHolo = e.IsHolo,
                                    ArtStyle = e.ArtStyle,
                                    Rarity = e.Rarity,
                                    StadiumAbility = e.StadiumAbility
                                }).ToList();
                var supporterCards = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true && o.Card.TypeOfCard == CardType.Supporter)
                    .Select(e => e.Card)
                    .OfType<Supporter>()
                                .Select(e => new SupporterDetail
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    TypeOfCard = e.TypeOfCard,
                                    Set = new PokemonSetListItem()
                                    {
                                        SetId = e.SetId,
                                        NameOfSet = e.Set.NameOfSet,
                                        SetAbbr = e.Set.SetAbbr,
                                        YearReleased = e.Set.YearReleased,
                                        TotalCards = e.Set.UncommonCount + e.Set.RareCount + e.Set.CommonCount,
                                    },
                                    IsHolo = e.IsHolo,
                                    ArtStyle = e.ArtStyle,
                                    Rarity = e.Rarity,
                                    SupporterAbility = e.SupporterAbility
                                }).ToList();
                var toolCards = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true && o.Card.TypeOfCard == CardType.Tool)
                    .Select(e => e.Card)
                    .OfType<Tool>()
                                .Select(e => new ToolDetail
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    TypeOfCard = e.TypeOfCard,
                                    Set = new PokemonSetListItem()
                                    {
                                        SetId = e.SetId,
                                        NameOfSet = e.Set.NameOfSet,
                                        SetAbbr = e.Set.SetAbbr,
                                        YearReleased = e.Set.YearReleased,
                                        TotalCards = e.Set.UncommonCount + e.Set.RareCount + e.Set.CommonCount,
                                    },
                                    IsHolo = e.IsHolo,
                                    ArtStyle = e.ArtStyle,
                                    Rarity = e.Rarity,
                                    ToolAbility = e.ToolAbility
                                }).ToList();

                var deck = new DeckDetail();
                deck.PokemonDetails = pokeCards;
                deck.StadiumDetails = stadiumCards;
                deck.ToolDetails = toolCards;
                deck.SupporterDetails = supporterCards;
                deck.ItemDetails = itemCards;
                deck.TotalCardCount = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID && o.IsInDeck == true)
                                .Select(e => new CardListItem
                                {
                                    Id = e.Card.Id,
                                    Name = e.Card.Name,
                                    CardType = e.Card.TypeOfCard
                                }).ToList().Count();
                return deck;

            }
        }
        public IEnumerable<CardListItem> GetMyCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ownerships
                    .Where(o => o.OwnerId == _ownerID)
                                .Select(e => new CardListItem
                                {
                                    Id = e.Card.Id,
                                    Name = e.Card.Name,
                                    CardType = e.Card.TypeOfCard
                                });
                return query.ToArray();
            }
        }
        public OwnershipDetail GetOwnerByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ownerships.Single(e => e.Id == id);

                return new OwnershipDetail
                {
                    OwnershipId = entity.Id,
                    IsInDeck = entity.IsInDeck,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC,
                    Card = new CardListItem()
                    {
                        Id = entity.Card.Id,
                        Name = entity.Card.Name,
                        CardType = entity.Card.TypeOfCard
                    }
                };
            }
        }
        public string SwitchInDeck(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ownerships.Single(e => e.Id == id);

                if(entity.IsInDeck == true)
                {
                    entity.IsInDeck = false;
                    ctx.SaveChanges();
                    return "Removed from deck";
                }
                else
                {
                    entity.IsInDeck = true;
                    ctx.SaveChanges();
                    return "Added to the deck";
                }
            }
        }
        public bool UpdateOwner(OwnershipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ownerships.Single(e => e.Id == model.OwnershipId);


                entity.CardID = model.CardID;
                entity.IsInDeck = model.IsInDeck;
                entity.ModifiedUTC = DateTime.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOwner(int ownershipId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ownerships.Single(e => e.Id == ownershipId && e.OwnerId == _ownerID);
                ctx.Ownerships.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
