using MoviesShopProxy;
using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using MoviesShopProxy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie() { Id = 1, Price = 200d, Title = "Lego movie", Year = DateTime.Now.AddYears(-1) };
            Facade facade = new Facade();
            facade.GetMovieRepository().Add(movie);
        }
    }
}
