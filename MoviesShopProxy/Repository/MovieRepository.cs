using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MoviesShopProxy.Repository
{
    public class MovieRepository
    {
        MovieShopContext ctx;

        public MovieRepository(MovieShopContext context)
        {
            ctx = context;
        }

        public List<Movie> ReadAll() {
            return ctx.Movies.Include(a => a.Genres).ToList();
        }
        public Movie Read(int id)
        {
            return ctx.Movies.Include(a => a.Genres).FirstOrDefault(m => m.Id == id);
        }

        public Movie Add(Movie movie) {
            if (movie.Genres != null)
            {
                //movie.Genres.ForEach(x => ctx.Genres.Attach(x));
                // -------- or like below for more code lines
                //foreach (var item in movie.Genres)
                //{
                //    ctx.Genres.Attach(item);
                //}
                // -------- to here!!!
            }

            //Create the queries
            ctx.Movies.Add(movie);
            //Execute the queries
            ctx.SaveChanges();

            return movie;
        }

        public Movie Remove(Movie movieToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
