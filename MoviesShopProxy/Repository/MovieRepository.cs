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
                return ctx.Movies.Include(a => a.Genre).ToList();
            }
        }

        public void Add(Movie movie) {
            using (var ctx = new MovieShopContextDBName())
            {
                //Create the queries
                ctx.Movies.Add(movie);
                //Execute the queries
                ctx.SaveChanges();
            }
        }



    }
}
