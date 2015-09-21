using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Context
{
    public class MovieShopContextDBName : DbContext
    {
        public MovieShopContextDBName(): base("MovieShop101"){}

        public DbSet<Movie> Movies { get; set; }
    }
}
