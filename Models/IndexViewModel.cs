using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment12_1.Models
{
    public class IndexViewModel : Controller
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
