using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gadgets.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int CustomerID { get; set; }
        public string PMethod { get; set; }
        public string GTotal { get; set; }
    }
}