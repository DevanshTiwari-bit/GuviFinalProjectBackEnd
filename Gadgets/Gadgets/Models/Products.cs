using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gadgets.Models
{
    public class Products
    {
       public int ProductID { get; set; }
       public string ProductName { get; set; }
       public string Category { get; set; }
       public string ProductDescription { get; set; }
       public string PhotoFileName { get; set; }
    }
}