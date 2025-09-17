using System;
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