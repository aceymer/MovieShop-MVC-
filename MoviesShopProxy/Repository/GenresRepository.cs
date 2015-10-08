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
        MovieShopContext ctx;

        public GenresRepository(MovieShopContext context)
        {
            ctx = context;
        }

        public List<Genre> ReadAll()
        {
            return ctx.Genres.ToList();
        }

        public void Add(Genre genre)
        {
            //Create the queries
            ctx.Genres.Add(genre);
            //Execute the queries
            ctx.SaveChanges();
        }
    }
}
