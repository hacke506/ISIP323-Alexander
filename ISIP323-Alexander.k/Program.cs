using System;
using System.Data;
class Product
{
    private static int nextCode = 1; // Статический счетчик для уникальных кодов

    public string Code { get; }           // Уникальный код, например "1", "2" и т.д.
    public string Name { get; set; }      // Название товара
    public decimal Price { get; set; }    // Цена
    public int Quantity { get; set; }     // Количество на складе
    public string Category { get; set; }  // Категория

    // Конструктор, вызывается при добавлении товара
    public Product(string name, decimal price, int quantity, string category)
    {
        Code = (nextCode++).ToString(); // автоматическая нумерация
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }

    // Метод для проверки, есть ли товар на складе
    public bool InStock()
    {
        return Quantity > 0;
    }

    public override string ToString()
    {
        return $"Код: {Code}, Название: {Name}, Цена: {Price}, Количество: {Quantity}, Категория: {Category}";
    }
}

class Programm
{
    static List<Product> products = new List<Product>();

    // Заранее задаем категории
    static string[] categories = { "Электроника", "Одежда", "Продукты" };

    static void Main(string[] args)
    {
        // Основной цикл меню
        while (true)
        {
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать поставку");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товаров");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
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
                    SearchProducts();
                    break;
                case "0":
                    return; // выход из программы
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    private static void AddProduct()
    {
        throw new NotImplementedException();
    }

    private static void RemoveProduct()
    {
        throw new NotImplementedException();
    }

    private static void RestockProduct()
    {
        throw new NotImplementedException();
    }

    private static void SellProduct()
    {
        throw new NotImplementedException();
    }

    private static void SearchProducts()
    {
        throw new NotImplementedException();
    }
}
