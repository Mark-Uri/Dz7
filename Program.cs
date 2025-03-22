using Microsoft.EntityFrameworkCore;
using Moq;
namespace DZ_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var category1 = new Category { Name = "Электроника" };
                var category2 = new Category { Name = "Одежда" };

                var product1 = new Product { Name = "Смартфон", Price = 599.99m, Category = category1 };
                var product2 = new Product { Name = "Футболка", Price = 19.99m, Category = category2 };
                var product3 = new Product { Name = "Ноутбук", Price = 999.99m, Category = category1 };



                var user1 = new User { Username = "Alice", Password = "1234" };
                var user2 = new User { Username = "Bob", Password = "qwerty" };

                var order1 = new Order { User = user1, Products = new() { product1, product3 } };
                var order2 = new Order { User = user2, Products = new() { product2 } };

                context.AddRange(category1, category2, product1, product2, product3, user1, user2, order1, order2);
                context.SaveChanges();
            }

            Console.WriteLine("Данные успешно добавлены в базу!");



            using (var context = new AppDbContext())
            {
                var userOrders = context.Set<UserOrderView>().ToList();

                foreach (var order in userOrders)
                {
                    string orderIdStr = order.OrderId?.ToString() ?? "Нет заказа";

                    string orderDateStr = order.OrderDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "Дата не указана";

                    Console.WriteLine($"Пользователь: {order.Username} сделал заказ ID: {orderIdStr} на дату {orderDateStr}");
                }
            }







        }
    }
}
