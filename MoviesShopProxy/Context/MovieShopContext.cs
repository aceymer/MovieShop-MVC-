using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Context
{
    public class MovieShopContext : DbContext
    {
        public MovieShopContext(): base(){}

        public DbSet<Movie> Movies { get; set; }
    }
}
