using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.DomainModel
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
    }
}
