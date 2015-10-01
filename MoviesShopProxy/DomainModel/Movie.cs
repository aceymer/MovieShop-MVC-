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
        [Display(Name = "TinkyWinky")]
        [StringLength(10)]
        public string Title { get; set; }
        [DataType("date")]
        [Display(Name = "Aweful drink")]
        public DateTime Year { get; set; }
        [Range(1, 9000)]
        [DataType("number")]
        public double Price { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
