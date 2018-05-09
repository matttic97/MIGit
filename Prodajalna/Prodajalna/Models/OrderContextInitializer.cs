using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prodajalna.Models
{
    public class OrderContextInitializer : DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            var produkti = new List<Product>()
            {
                new Product(){Name="Paradižnikova juha", Price=1.3m, ActualCost=0.99m },
                new Product(){Name="Bong", Price=12.3m, ActualCost=9.99m },
                new Product(){Name="deeW", Price=5, ActualCost=4.88m }
            };
            foreach(var p in produkti)
                context.Products.Add(p);
            context.SaveChanges();

            var narocilo = new Order() { Customer = "Angelca" };
            var vrstice = new List<OrderDetail>()
            {
                new OrderDetail(){Product=produkti[0], Quantity=2, Order=narocilo},
                new OrderDetail(){Product=produkti[1], Quantity=4, Order=narocilo}
            };
            context.Orders.Add(narocilo);
            vrstice.ForEach(x => context.OrderDetails.Add(x));
            context.SaveChanges();
        }
    }
}