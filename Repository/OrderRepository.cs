using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    class OrderRepository
    {
        public void LoadOrderWithProductsExplicitly(int orderId)
        {
            using var context = new AppDbContext();



            var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                
                context.Entry(order).Collection(o => o.Products).Load();


                Console.WriteLine($"Заказ ID: {order.Id}");
                foreach (var product in order.Products)
                {
                    
                    context.Entry(product).Reference(p => p.Category).Load();
                    Console.WriteLine($"  Товар: {product.Name} | Категория: {product.Category.Name}");
                }
            }
        }
    }
}
