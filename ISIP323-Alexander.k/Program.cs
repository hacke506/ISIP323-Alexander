using System;
using System.Collections.Generic;
public class Product
{
    private static int nextId = 1; // статическая переменная для автоматической нумерации

    public string Code { get; private set; } // уникальный код
    public string Name { get; set; } // название
    public decimal Price { get; set; } // цена
    public int Quantity { get; set; } // количество
    public string Category { get; set; } // категория

    // Конструктор для создания товара
    public Product(string name, decimal price, int quantity, string category)
    {
        Code = "1" + nextId.ToString("D4"); // например, 10001, 10002, ...
        nextId++;
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }

    // Свойство, показывающее есть ли товар
    public bool IsAvailable => Quantity > 0;

    // Для вывода всей информации о товаре
    public override string ToString()
    {
        return $"Код: {Code} | Название: {Name} | Цена: {Price} руб. | Количество: {Quantity} | Категория: {Category} | Остаток: {(IsAvailable ? "Есть" : "Нет")}";
    }
}

class Program
{
    static List<Product> products = new List<Product>(); // коллекция товаров

    static void Main()
    {
        // ЭТАП 2: Предопределим категории
        var categories = new List<string> { "Электроника", "Одежда", "Продукты" };

        while (true)
        {
            Console.WriteLine("\n--- МЕНЮ ---");
            Console.WriteLine("1 - Добавить товар");
            Console.WriteLine("2 - Удалить товар");
            Console.WriteLine("3 - Заказать поставку");
            Console.WriteLine("4 - Продать товар");
            Console.WriteLine("5 - Поиск товара");
            Console.WriteLine("0 - Выход");
            Console.Write("Введите номер команды: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(categories);
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    RestockProduct();
                    break;
                case "4":
                    SellProduct();
                    break;
                case "5":
                    SearchProduct();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    private static void SearchProduct()
    {
        throw new NotImplementedException();
    }

    private static void SellProduct()
    {
        throw new NotImplementedException();
    }

    private static void RestockProduct()
    {
        throw new NotImplementedException();
    }

    private static void AddProduct(List<string> categories)
    {
        throw new NotImplementedException();
    }

    private static void RemoveProduct()
    {
        throw new NotImplementedException();
    }
}

