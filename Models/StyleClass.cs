using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Assignment12_1.Models
{
    public class StyleClass
    {
        [Key]
        public int StyleID { get; set; }
        public string StyleName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
