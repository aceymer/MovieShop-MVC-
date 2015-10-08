using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Repository
{
    public class GenresRepository
    {

        public List<Genre> ReadAll()
        {
            using (var ctx = new MovieShopContextTest())
            {
                return ctx.Genres.ToList();
            }
        }

        public void Add(Genre genre)
        {
            using (var ctx = new MovieShopContextTest())
            {
                //Create the queries
                ctx.Genres.Add(genre);
                //Execute the queries
                ctx.SaveChanges();
            }
        }
    }
}
