using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Context
{
    public class MovieShopContextTest : MovieShopContext
    {
        public MovieShopContextTest(): base("MovieShopTest"){
            Database.SetInitializer(new MovieDBInitializeTest());
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasMany(x => x.Genres).WithMany(y => y.Movies);
        }
    }
}
