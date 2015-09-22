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
        private MovieRepository movieRepo;
        private GenresRepository genresRepo;

        public MovieRepository GetMovieRepository()
        {
            if (movieRepo == null) {
                movieRepo = new MovieRepository();
            }
            return movieRepo;
        }
        
        public GenresRepository GetGenresRepository()
        {
            if (genresRepo == null)
            {
                genresRepo = new GenresRepository();
            }
            return genresRepo;
        }
    }
}
