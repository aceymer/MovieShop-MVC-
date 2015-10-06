using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using MoviesShopProxy.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopTest
{
    [TestFixture]
    public class MovieRepositoryTest
    {
        [Test]
        public void Movie_is_db()
        {
            MovieRepository repo = new MovieRepository();

            List<Movie> movie = repo.ReadAll();
            bool toad2Found = false;
            foreach (var item in movie)
            {
                if ("Toad 2".Equals(item.Title)) {
                    toad2Found = true;
                }
            }
            Assert.IsTrue(toad2Found);

        }

        [Test]
        public void Add_multi_genre_to_movie_added_in_db()
        {
            MovieRepository repo = new MovieRepository();

            Movie movie = new Movie() { Title = "Svend the rich", Price=222, Year = DateTime.Now};

            List<Genre> genres = new List<Genre>();
            GenresRepository genreRepo = new GenresRepository();
            List<Genre> genresFound = genreRepo.ReadAll();
            genres.Add(genresFound[0]);
            genres.Add(genresFound[2]);
            movie.Genres = genres;

            repo.Add(movie);


            List<Genre> genresFound2 = genreRepo.ReadAll();
            List<Movie> movies = repo.ReadAll();

        }
    }
}
