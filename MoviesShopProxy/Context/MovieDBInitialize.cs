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

    public class MovieDBInitialize : DropCreateDatabaseIfModelChanges<MovieShopContextDBName>
    {
        protected override void Seed(MovieShopContextDBName context)
        {
         
            Genre g1 = context.Genres.Add(new Genre() { Name = "Nice" });
            Genre g2 = context.Genres.Add(new Genre() { Name = "Cool" });
            Genre g3 = context.Genres.Add(new Genre() { Name = "Cheese" });

            context.Movies.Add(new Movie() { Price = 102, Genre = g1, Title="Toad 2", Year=DateTime.Now.AddYears(-20) });
            context.Movies.Add(new Movie() { Price = 103, Genre = g3, Title = "Toad", Year = DateTime.Now.AddYears(-30) });
            context.Movies.Add(new Movie() { Price = 110, Genre = g3, Title = "Toad 3", Year = DateTime.Now.AddYears(-10) });
            context.Movies.Add(new Movie() { Price = 130, Genre = g1, Title = "Toad 4", Year = DateTime.Now.AddYears(-1) });
            
            base.Seed(context);
        }
    }
}
