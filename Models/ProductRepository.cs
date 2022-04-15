using System.Collections.Generic;

namespace Assignment12_1.Models
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products { get; set; } //property for the product list

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DeleteProduct(int? id)
        {
            var prod=Products.Find(x => x.Id == id);
            Products.Remove(prod);
        }
        public void UpdateProduct(Product product)
        {
            var prod=Products.Find(x=>x.Id == product.Id);
            if (prod != null)
            {
                prod.Id = product.Id;
                prod.Name = product.Name;
                prod.Style = product.Style;
                prod.Description = product.Description;
                prod.Price = product.Price;
                prod.ImgName= product.ImgName;  
                prod.Stock= product.Stock;
            }
        }

        public Product GetProduct(int? id) //using a nullable int to allow nulls
        {
            if (id == null)
            {
                return null;
            }

            else
            {
                return Products.Find(x => x.Id == id);
            }
        }

        public IEnumerable<Product> InitializeData()
        {
            return Products;
        }

        public ProductRepository()
        {
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 101,
                    Name = "Jordan 1 White",
                    Style = Style.Jordan,
                    Description = "White Jordan with red and gray accents",
                    Price = 250,
                    ImgName = "jordan1.jpg",
                    Stock=Stock.Yes
                },
                new Product()
                {
                    Id = 102,
                    Name = "Jordan 1 M.O.T.Y.",
                    Style = Style.Jordan,
                    Description = "White Jordan with Christmas color accents",
                    Price = 199,
                    ImgName = "jordan2.jpg",
                    Stock=Stock.Yes
                },
               new Product()
                {
                    Id = 103,
                    Name = "Jordan 1 Mocha",
                    Style = Style.Jordan,
                    Description = "White Jordan with brown suede and black leather accents",
                    Price = 500,
                    ImgName = "jordan3.jpg",
                    Stock=Stock.No
                },
               new Product()
                {
                    Id = 104,
                    Name = "Jordan 1 Patent University",
                    Style = Style.Jordan,
                    Description = "White Jordan with UNC colorway",
                    Price = 650,
                    ImgName = "jordan4.jpg",
                    Stock = Stock.No
                },
               new Product()
                {
                    Id = 105,
                    Name = "Jordan 1 Oreo",
                    Style = Style.Jordan,
                    Description = "White Jordan with black accents",
                    Price = 225,
                    ImgName = "jordan5.jpg",
                    Stock=Stock.Yes
                }
            };
        }


    }
}
