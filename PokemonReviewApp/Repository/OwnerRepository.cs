using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.IRepository;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _ownerRepository = context;
            _mapper = mapper;
        }

        public bool CreateOwner(Owner owner)
        {
            _ownerRepository.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _ownerRepository.Remove(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _ownerRepository.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfPokemon(int pokeId)
        {
            return _ownerRepository.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _ownerRepository.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)  
        {
            return _ownerRepository.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _ownerRepository.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _ownerRepository.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _ownerRepository.Update(owner);
            return Save();
        }
    }
}
