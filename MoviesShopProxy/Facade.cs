using MoviesShopProxy.Context;
using MoviesShopProxy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy
{
    public class Facade
    {
        private MovieShopContext ctx;
        private MovieRepository movieRepo;
        private GenresRepository genresRepo;

        public Facade(MovieShopContext context = null)
        {
            ctx = context != null ? context : new MovieShopContextDev();
        }

        public MovieRepository GetMovieRepository()
        {
            
            return movieRepo = new MovieRepository(ctx);
        }
        
        public GenresRepository GetGenresRepository()
        {
           return genresRepo = new GenresRepository();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
