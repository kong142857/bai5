// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace bai5
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // Lớp cha Product
        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }

            public Product(string name, double price, string description, int quantity)
            {
                Name = name;
                Price = price;
                Description = description;
                Quantity = quantity;
            }

            // Phương thức hiển thị thông tin sản phẩm
            public virtual void Display()
            {
                Console.WriteLine($"Ten san pham: {Name}, Gia: {Price}, Mo ta: {Description}, So luong: {Quantity}");
            }
        }

        // Lớp con Electronic kế thừa từ Product
        class Electronic : Product
        {
            public int WarrantyMonths { get; set; }

            public Electronic(string name, double price, string description, int quantity, int warrantyMonths)
                : base(name, price, description, quantity)
            {
                WarrantyMonths = warrantyMonths;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine($"Bao hanh: {WarrantyMonths} thang");
            }
        }

        // Lớp con Clothing kế thừa từ Product
        class Clothing : Product
        {
            public string Size { get; set; }
            public string Color { get; set; }

            public Clothing(string name, double price, string description, int quantity, string size, string color)
                : base(name, price, description, quantity)
            {
                Size = size;
                Color = color;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine($"Kich thuoc: {Size}, Mau sac: {Color}");
            }
        }

        // Lớp con Food kế thừa từ Product
        class Food : Product
        {
            public DateTime ExpirationDate { get; set; }

            public Food(string name, double price, string description, int quantity, DateTime expirationDate)
                : base(name, price, description, quantity)
            {
                ExpirationDate = expirationDate;
            }

            public override void Display()
            {
                base.Display();
                Console.WriteLine($"Ngay het han: {ExpirationDate.ToShortDateString()}");
            }
        }

        // Lớp ShoppingCart để quản lý giỏ hàng
        class ShoppingCart
        {
            private List<Product> cart = new List<Product>();

            // Thêm sản phẩm vào giỏ
            public void AddProduct(Product product)
            {
                cart.Add(product);
            }

            // Hiển thị danh sách sản phẩm trong giỏ
            public void DisplayCart()
            {
                Console.WriteLine("Danh sach san pham trong gio hang:");
                foreach (var product in cart)
                {
                    product.Display();
                    Console.WriteLine("-----------------------");
                }
            }

            // Tính tổng giá trị của giỏ hàng
            public double CalculateTotal()
            {
                double total = 0;
                foreach (var product in cart)
                {
                    total += product.Price * product.Quantity;
                }
                return total;
            }
        }

        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("Chon loai san pham de them gio hang:");
                Console.WriteLine("1. Đien tu");
                Console.WriteLine("2. Quan ao");
                Console.WriteLine("3. Thuc pham");
                Console.WriteLine("4. Hien thi gio hang");
                Console.WriteLine("5. Tinh tong gia tri gio hang");
                Console.WriteLine("6. Thoát");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Nhap ten san pham đien tu:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Nhap gia:");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap mo ta:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Nhap so luong:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap so thang bao hanh:");
                    int warrantyMonths = int.Parse(Console.ReadLine());

                    Electronic electronic = new Electronic(name, price, description, quantity, warrantyMonths);
                    cart.AddProduct(electronic);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Nhap ten san pham quan ao:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Nhap gia:");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap mo ta:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Nhap so luong:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap kich thuoc:");
                    string size = Console.ReadLine();
                    Console.WriteLine("Nhap mau sac:");
                    string color = Console.ReadLine();

                    Clothing clothing = new Clothing(name, price, description, quantity, size, color);
                    cart.AddProduct(clothing);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Nhap ten san pham thuc pham:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Nhap gia:");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap mo ta:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Nhap so luong:");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap ngay het han (yyyy-mm-dd):");
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                    Food food = new Food(name, price, description, quantity, expirationDate);
                    cart.AddProduct(food);
                }
                else if (choice == 4)
                {
                    cart.DisplayCart();
                }
                else if (choice == 5)
                {
                    double total = cart.CalculateTotal();
                    Console.WriteLine($"Tong gia tri gio hang: {total}");
                }
                else if (choice == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }
            }
        }
    }

}
