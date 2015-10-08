using MoviesShopProxy;
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
        Facade facade;
        [SetUp]
        public void SetUp() {
            facade = new Facade(new MovieShopContextTest());
        }

        [TearDown]
        public void TearDown()
        {
            facade.Dispose();
        }

        [Test]
        public void Movie_is_in_db_after_add()
        {

            Movie movie = new Movie() {Id = -1, Title = "Svend the rich", Price = 222, Year = DateTime.Now };

            List<Genre> genres = new List<Genre>();
            List<Genre> genresFound = facade.GetGenresRepository().ReadAll();
            genres.Add(genresFound[0]);
            genres.Add(genresFound[2]);
            movie.Genres = genres;

            Movie movieAdded = facade.GetMovieRepository().Add(movie);

            Assert.IsTrue(movieAdded.Id != -1);

            Movie movieAddedReturned = facade.GetMovieRepository().Read(movieAdded.Id);

            Assert.AreSame(movieAdded, movieAddedReturned);

        }

        [Test]
        public void Movie_is_removed__from_db_after_delete()
        {

            List<Movie> movies = facade.GetMovieRepository().ReadAll();
            Assert.IsTrue(movies.Count > 0, "We need atleast one movie to do the test");
            Movie movieToRemove = movies[0];
            Movie movieRemoved = facade.GetMovieRepository().Remove(movieToRemove);
            Assert.AreSame(movieToRemove, movieRemoved);
            /*Movie movieRemovedReturned = facade.GetMovieRepository().Read(movieRemoved.Id);
            Assert.IsNull(movieRemovedReturned);*/
        }

        [Test]
        public void Add_multi_genre_to_movie_added_in_db()
        {
            Movie movie = new Movie() { Title = "Svend the rich", Price=222, Year = DateTime.Now};

            List<Genre> genres = new List<Genre>();
            List<Genre> genresFound = facade.GetGenresRepository().ReadAll();
            genres.Add(genresFound[0]);
            genres.Add(genresFound[2]);
            movie.Genres = genres;

            facade.GetMovieRepository().Add(movie);


            List<Genre> genresFound2 = facade.GetGenresRepository().ReadAll();
            List<Movie> movies = facade.GetMovieRepository().ReadAll();

        }
    }
}
