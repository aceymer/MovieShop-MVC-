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
            facade = null;
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
            Movie movieRemovedReturned = facade.GetMovieRepository().Read(movieRemoved.Id);
            Assert.IsNull(movieRemovedReturned);
        }

        [Test]
        public void Genre_in_movie_is_updated_after_update()
        {
            Movie movie = facade.GetMovieRepository().ReadAll().First();
            movie.Genres = new List<Genre>();
            Movie movieUpdated = facade.GetMovieRepository().Update(movie);
            Assert.IsFalse(movieUpdated.Genres.Any());
            Movie movieFromDB = facade.GetMovieRepository().ReadAll().First();
            Assert.IsFalse(movieFromDB.Genres.Any());

            //Test what happens if we add 1 genre!
            List<Genre> genres = new List<Genre>();
            Genre genre = facade.GetGenresRepository().ReadAll().First();
            genres.Add(genre);
            movie.Genres = genres;
            Movie movieUpdated2 = facade.GetMovieRepository().Update(movie);
            Assert.IsTrue(movieUpdated2.Genres.Any());
            Movie movieFromDB2 = facade.GetMovieRepository().ReadAll().First();
            Assert.IsTrue(movieFromDB2.Genres.Any());

            //Test what happens if we add 1 genre again!
            List<Genre> genres2 = new List<Genre>();
            Genre genre2 = facade.GetGenresRepository().ReadAll().First();
            genres2.Add(genre2);
            movie.Genres = genres2;
            Movie movieUpdated3 = facade.GetMovieRepository().Update(movie);
            Assert.IsTrue(movieUpdated3.Genres.Any());
            Movie movieFromDB3 = facade.GetMovieRepository().ReadAll().First();
            Assert.IsTrue(movieFromDB3.Genres.Count == 1);

            facade = new Facade(new MovieShopContextTest());

            //Test what happens if we add 1 genre again!
            Movie rePulledMovie = facade.GetMovieRepository().Read(movie.Id);
            List<Genre> genres3 = new List<Genre>();
            Genre genre3 = facade.GetGenresRepository().ReadAll().Last();
            Genre genre4 = facade.GetGenresRepository().ReadAll()[1];
            genres3.Add(genre3);
            genres3.Add(genre4);
            rePulledMovie.Genres = genres3;
            Movie movieUpdated4 = facade.GetMovieRepository().Update(rePulledMovie);
            Assert.IsTrue(movieUpdated4.Genres.Any());
            Movie movieFromDB4 = facade.GetMovieRepository().Read(rePulledMovie.Id);
            Assert.IsTrue(movieFromDB4.Genres.Count == 2);
            Assert.IsTrue(movieFromDB4.Genres.Contains(genre3), "did not contain genre3");
            Assert.IsTrue(movieFromDB4.Genres.Contains(genre4), "did not contain genre4");


            //Add new Genre
            rePulledMovie.Genres.Add(new Genre() { Name = "Namnam"});
            Movie movieUpdated5 = facade.GetMovieRepository().Update(rePulledMovie);
            Assert.IsTrue(movieUpdated5.Genres.Count == 3);
            Assert.IsTrue(facade.GetGenresRepository().ReadAll().Count == 4);

        }

        [Test]
        public void Movie_is_updated_after_update()
        {
            Movie movie = facade.GetMovieRepository().ReadAll().First();
            Assert.IsNotNull(movie, "We need atleast one movie to do the test");
            int newPrice = 10;
            movie.Price = newPrice;

            string newTitle = "Ost";
            movie.Title = newTitle;

            DateTime newYear = DateTime.Now;
            movie.Year = newYear;

            Movie updatedMovie1 = facade.GetMovieRepository().Update(movie);
            Assert.AreEqual(newPrice, updatedMovie1.Price);
            Assert.AreEqual(newTitle, updatedMovie1.Title);
            Assert.AreEqual(newYear, updatedMovie1.Year);

            Movie updatedMovie2 = facade.GetMovieRepository().Read(movie.Id);
            Assert.AreEqual(newPrice, updatedMovie2.Price);
            Assert.AreEqual(newTitle, updatedMovie2.Title);
            Assert.AreEqual(newYear, updatedMovie2.Year);
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
