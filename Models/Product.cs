using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment12_1.Models
{   public enum Style
    {
       Jordan,
       Nike,
       Adidas,
       Yeezy
    }

    public enum Stock
    {
        Yes,
        No
    }
    public class Product
    {

        //changes display name to inventory ID and makes the ID a required value
        [Required, Display(Name ="Inventory ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //changes the display name to shoe name and makes the value required
        [Required, Display(Name ="Shoe Name")]
        public string Name { get; set; }
        [Required] //makes the she style required
        public Style Style { get; set; }
        [MaxLength(100, ErrorMessage="There's a picture of the shoe, you don't need to write a book!")]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string ImgName { get; set; }
        public Stock Stock { get; set; }
        public int StyleID { get; set; }
        public int StockId { get; set; }
    }
}
