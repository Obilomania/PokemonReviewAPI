﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository.IRepository
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
    }
}
