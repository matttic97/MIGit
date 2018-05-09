using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodajalna.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}