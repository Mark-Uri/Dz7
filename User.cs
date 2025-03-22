using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DZ_4
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 50 символов")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password { get; set; }

        public byte[]? ProfilePicture { get; set; }



        public virtual List<Order> Orders { get; set; } = new();
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Название продукта не может быть длиннее 100 символов")]
        public string Name { get; set; }


        [Required]
        [Range(0.01, 100000, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Order> Orders { get; set; } = new();
    }

   
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "ID пользователя обязателен")]
        public int UserId { get; set; }


            
        [Required] 
        public User User { get; set; }

        [MinLength(1, ErrorMessage = "Заказ должен содержать хотя бы один товар")]
        public List<Product> Products { get; set; } = new();
    }

    public class Category
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Название категории обязательно")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно содержать от 3 до 100 символов")]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new();
    }

    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Комментарий не может превышать 500 символов")]
        public string Comment { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

