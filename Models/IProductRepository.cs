using System.Collections.Generic;
namespace Assignment12_1.Models
{
    public interface IProductRepository
    {
       List<Product> Products { get; set; } //will hold the product list
       IEnumerable<Product> InitializeData();
        Product GetProduct(int? id); //gets the employees by the id
        //CRUD functions
        void AddProduct (Product product);  
        void UpdateProduct (Product product);
        void DeleteProduct (int? id);

    }
}
