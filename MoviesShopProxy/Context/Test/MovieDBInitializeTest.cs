using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Context
{

    /// <summary>
    /// DropCreateDatabaseIfModelChanges
    /// </summary>

    public class MovieDBInitializeTest : DropCreateDatabaseAlways<MovieShopContextTest>
    {
        protected override void Seed(MovieShopContextTest context)
        {
         
            Genre g1 = context.Genres.Add(new Genre() { Name = "Nice" });
            Genre g2 = context.Genres.Add(new Genre() { Name = "Cool" });
            Genre g3 = context.Genres.Add(new Genre() { Name = "Cheese" });

            context.Movies.Add(new Movie() { Price = 102, Genres = new List<Genre> { g1, g2 }, Title="Toad 2", Year=DateTime.Now.AddYears(-20) });
            context.Movies.Add(new Movie() { Price = 103, Genres = new List<Genre> { g3, g2 }, Title = "Toad", Year = DateTime.Now.AddYears(-30) });
            context.Movies.Add(new Movie() { Price = 110, Genres = new List<Genre> { g1, g2 }, Title = "Toad 3", Year = DateTime.Now.AddYears(-10) });
            context.Movies.Add(new Movie() { Price = 130, Genres = new List<Genre> { g3, g2 }, Title = "Toad 4", Year = DateTime.Now.AddYears(-1) });
            
            base.Seed(context);
        }
    }
}
