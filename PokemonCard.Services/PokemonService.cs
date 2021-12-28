using PokemonCard.Data;
using PokemonCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCard.Services
{
    public class PokemonService
    {
        private readonly Guid _userId;

        

        public PokemonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePokemon(PokemonCreate model)
        {
            var entity =
                new Pokemon()
                {
                    Name = model.Name,
                    TypeOfCard = CardType.Pokemon,
                    SetId = model.SetId,
                    PokemonType = model.PokemonType,
                    Evolves = model.Evolves,
                    Attack1 = model.Attack1,
                    Attack2 = model.Attack2,                    
                    Rarity = model.Rarity,
                    ArtStyle = model.ArtStyle
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pokemons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PokemonListItem> GetPokemons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pokemons
                        .Select(
                            e =>
                                new PokemonListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<PokemonListItem> GetPokemonsByRarity(Rarity rarity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pokemons.Where(x=> x.Rarity == rarity)
                        .Select(
                            e =>
                                new PokemonListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CardType = e.TypeOfCard
                                }
                        );

                return query.ToArray();
            }
        }

        public PokemonDetail GetPokemonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pokemons
                        .Single(e => e.Id == id);
                return
                    new PokemonDetail
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
                        PokemonType = entity.PokemonType,
                        Evolves = entity.Evolves,
                        Attack1 = entity.Attack1,
                        Attack2 = entity.Attack2,                               TypeOfCard = entity.TypeOfCard,
                        IsHolo = entity.IsHolo,
                        ArtStyle = entity.ArtStyle,
                        Rarity = entity.Rarity
                    };
            }
        }
        public bool UpdatePokemon(PokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pokemons.Single(e => e.Name == model.Name);
                entity.Name = model.Name;
                entity.SetId = model.SetId;
                entity.PokemonType = model.PokemonType;
                entity.Evolves = model.Evolves;
                entity.Attack1 = model.Attack1;
                entity.Attack2 = model.Attack2;                
                entity.IsHolo = model.IsHolo;
                entity.ArtStyle = model.ArtStyle;
                entity.Rarity = model.Rarity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePokemon(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pokemons
                        .Single(e => e.Id == id);

                ctx.Pokemons.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
