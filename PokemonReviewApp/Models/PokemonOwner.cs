namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {
        public int PokemmodId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
