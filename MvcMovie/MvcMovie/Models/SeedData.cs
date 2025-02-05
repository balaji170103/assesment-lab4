
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "sankranthi",
                    ReleaseDate = DateTime.Parse("2023-2-10"),
                    Genre = "Comedy",
                    Rating = "6.6",
                    Price = 10.99M
                },
                new Movie
                {
                    Title = "bahubali ",
                    ReleaseDate = DateTime.Parse("2022-3-09"),
                    Genre = "Action",
                    Rating = "7.8",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "iddarmayilatho",
                    ReleaseDate = DateTime.Parse("2011-07-12"),
                    Genre = "Romantic comedy",
                    Rating = "8.4",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "kalki",
                    ReleaseDate = DateTime.Parse("2024-10-02"),
                    Genre = "Adventure",
                    Rating = "9.3",
                    Price = 5.99M
                }
            );
            context.SaveChanges();
        }
    }
}
