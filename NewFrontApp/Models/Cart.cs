using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFrontApp.Models
{
    public class Cart
    {
        public string Name { get; set; }
        public string IdProduct { get; set; }
        public decimal Price { get; set; }     
        public int Quantity { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }
    }
}