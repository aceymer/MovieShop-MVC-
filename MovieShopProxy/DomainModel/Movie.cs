using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopProxy.DomainModel
{
    public class Movie
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }

    }
}
