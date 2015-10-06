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
        public List<Movie> ReadAll() {
            using (var ctx = new MovieShopContextDBName()) {
                return ctx.Movies.Include(a => a.Genres).ToList();
            }
        }
        public Movie Read(int id)
        {
            using (var ctx = new MovieShopContextDBName())
            {
                return ctx.Movies.Include(a => a.Genres).FirstOrDefault(m => m.Id == id);
            }
        }

        public void Add(Movie movie) {
            using (var ctx = new MovieShopContextDBName())
            {
                foreach (var item in movie.Genres)
                {
                    ctx.Genres.Attach(item);
                }
                //Create the queries
                ctx.Movies.Add(movie);
                //Execute the queries
                try
                {

                    ctx.SaveChanges();
                }
                catch (Exception e)
                {

                }
            }
        }



    }
}
