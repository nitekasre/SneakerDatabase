using System.Collections.Generic;

namespace Assignment12_1.Models
{
    public class DBData : IProductRepository
    {
        public List<Product> Products { get; set; }
        private ProductContext _productContext;
        public DBData(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void AddProduct(Product product)
        {
            if (product.Style.ToString() == "Jordan")
            {
                product.StyleID = 1;
            }
            if (product.Style.ToString() == "Nike")
            {
                product.StyleID = 2;
            }
            if (product.Style.ToString() == "Adidas")
            {
                product.StyleID = 3;
            }
            if (product.Style.ToString() == "Yeezy")
            {
                product.StyleID = 4;
            }
            if (product.Stock.ToString() == "Yes")
            {
                product.StockId = 1;
            }
            if (product.Stock.ToString() == "No")
            {
                product.StockId = 2;
            }

            _productContext.Products.Add(product);
            _productContext.SaveChanges();
        }

        public void DeleteProduct(int? id)
        {
            var prod = _productContext.Products.Find(id);
            if (prod != null)
            {
                _productContext.Products.Remove(prod);
                _productContext.SaveChanges();
            }
        }

        public Product GetProduct(int? id)
        {
            return _productContext.Products.Find(id);
        }

        public IEnumerable<Product> InitializeData()
        {
            return _productContext.Products;
        }

        public void UpdateProduct(Product product)
        {
            Product prod = _productContext.Products.Find(product.Id);
            if (prod != null)
            {
                prod.Id=product.Id;
                prod.Name=product.Name;
                prod.Style=product.Style;
                prod.Description=product.Description;
                prod.Price=product.Price;
                prod.Stock=product.Stock;
                if (product.Style.ToString() == "Jordan")
                {
                    product.StyleID = 1;
                }
                if (product.Style.ToString() == "Nike")
                {
                    product.StyleID = 2;
                }
                if (product.Style.ToString() == "Adidas")
                {
                    product.StyleID = 3;
                }
                if (product.Style.ToString() == "Yeezy")
                {
                    product.StyleID = 4;
                }
                if (product.Stock.ToString() == "Yes")
                {
                    product.StockId = 1;
                }
                if (product.Stock.ToString() == "No")
                {
                    product.StockId = 2;
                }
                _productContext.SaveChanges();
            }
        }
    }
}
