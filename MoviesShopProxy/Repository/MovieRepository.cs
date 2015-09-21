using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Repository
{
    public class MovieRepository
    {
        public void Add(Movie movie) {
            using (var ctx = new MovieShopContext())
            {
                //Movie movie = new Movie() { Id = 1, Price=200d, Title="Lego movie", Year=DateTime.Now.AddYears(-1) };
                //Movie movie = ctx.Movies.FirstOrDefault(x => x.Id == 1);
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }

    }
}
