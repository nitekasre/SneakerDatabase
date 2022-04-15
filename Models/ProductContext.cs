using Microsoft.EntityFrameworkCore;
namespace Assignment12_1.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {
            //initializes everything
        }

        //table to be included in the database
        public DbSet<Product> Products { get; set; }
        public DbSet<StyleClass> Styles { get; set; }
        public DbSet<StockClass> Stocks { get; set; }

        //dummy data to be added to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StyleClass>().HasData(
                new StyleClass { StyleID = 1, StyleName="Jordan"},
                new StyleClass { StyleID = 2, StyleName = "Nike" },
                new StyleClass { StyleID = 3, StyleName = "Adidas" },
                new StyleClass { StyleID = 4, StyleName = "Yeezy" }
                    );

            modelBuilder.Entity<StockClass>().HasData(
                new StockClass { StockID = 1, StockName = "Yes" },
                new StockClass { StockID = 2, StockName = "No" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id=101, Name="Jordan 1 White", Style=Style.Jordan, Description= "White Jordan with red and gray accents", Price=250, ImgName="jordan1.jpg", Stock=Stock.Yes },
                new Product { Id = 102, Name = "Jordan 1 Man of the Year", Style = Style.Jordan, Description = "White Jordan with Christmas color accents", Price = 199, ImgName = "jordan2.jpg", Stock = Stock.Yes },
                new Product { Id = 103, Name = "Jordan 1 Mocha", Style = Style.Jordan, Description = "White Jordan with Christmas color accents", Price = 450, ImgName = "jordan3.jpg", Stock = Stock.No },
                new Product { Id = 104, Name = "Jordan 1 Satin University", Style = Style.Jordan, Description = "White Jordan with UNC colorway", Price = 200, ImgName = "jordan4.jpg", Stock = Stock.No },
                new Product { Id = 105, Name = "Jordan 1 Oreo", Style = Style.Jordan, Description = "White Jordan with black accents", Price = 200, ImgName = "jordan5.jpg", Stock = Stock.No }
                );
        }
    }
}
