using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Context
{
    public class MovieShopContextUsingConnectionString : DbContext
    {
        public MovieShopContextUsingConnectionString(): 
            base("name=MovieShopDBConnectionString") {}

        public DbSet<Movie> Movies { get; set; }
    }
}
