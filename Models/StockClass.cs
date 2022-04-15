using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Assignment12_1.Models
{
    public class StockClass
    {
        [Key]
        public int StockID { get; set; }    
        public string StockName { get; set; }   
        public virtual ICollection<Product>Products { get; set; }
    }
}
