using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }

    class Program
    {
        static List<Expense> expenses = new List<Expense>();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество операций (от 2 до 40):");
            int count;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out count) && count >= 2 && count <= 40)
                    break;
                Console.WriteLine("Некорректный ввод. Введите число от 2 до 40:");
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите трату #{i + 1} (формат: Название;Сумма):");
                string input = Console.ReadLine();
                var parts = input.Split(';');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Некорректный формат. Попробуйте снова.");
                    i--;
                    continue;
                }
                string name = parts[0].Trim();
                if (decimal.TryParse(parts[1].Trim(), out decimal amount))
                {
                    expenses.Add(new Expense { Name = name, Amount = amount });
                }
                else
                {
                    Console.WriteLine("Некорректная сумма. Попробуйте снова.");
                    i--;
                }
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Вывод данных");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Сортировка по цене");
                Console.WriteLine("4. Конвертация валюты");
                Console.WriteLine("5. Поиск по названию");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PrintExpenses();
                        break;
                    case "2":
                        ShowStatistics();
                        break;
                    case "3":
                        BubbleSortExpenses();
                        Console.WriteLine("Отсортировано по цене (по возрастанию).");
                        break;
                    case "4":
                        ConvertCurrency();
                        break;
                    case "5":
                        SearchByName();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        static void PrintExpenses()
        {
            Console.WriteLine("\nВсе траты:");
            foreach (var expense in expenses)
            {
                Console.WriteLine($"- {expense.Name}: {expense.Amount} руб");
            }
        }

        static void ShowStatistics()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("Нет данных для статистики.");
                return;
            }

            decimal sum = 0;
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            decimal total = 0;

            foreach (var expense in expenses)
            {
                decimal amount = expense.Amount;
                sum += amount;
                if (amount > max) max = amount;
                if (amount < min) min = amount;
            }

            decimal average = sum / expenses.Count;

            Console.WriteLine($"\nСтатистика:");
            Console.WriteLine($"Общая сумма: {sum} руб");
            Console.WriteLine($"Среднее: {average:F2} руб");
            Console.WriteLine($"Максимальное: {max} руб");
            Console.WriteLine($"Минимальное: {min} руб");
        }

        static void BubbleSortExpenses()
        {
            for (int i = 0; i < expenses.Count - 1; i++)
            {
                for (int j = 0; j < expenses.Count - i - 1; j++)
                {
                    if (expenses[j].Amount > expenses[j + 1].Amount)
                    {
                        var temp = expenses[j];
                        expenses[j] = expenses[j + 1];
                        expenses[j + 1] = temp;
                    }
                }
            }
        }

        static void ConvertCurrency()
        {
            Console.WriteLine("Выберите курс валюты или введите свой:");
            Console.WriteLine("1. 1 USD = 75 RUB");
            Console.WriteLine("2. 1 EUR = 85 RUB");
            Console.WriteLine("3. Ввести свой курс");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            decimal rate = 0;

            switch (choice)
            {
                case "1":
                    rate = 75;
                    break;
                case "2":
                    rate = 85;
                    break;
                case "3":
                    Console.Write("Введите курс (1 единица валюты = ? рублей): ");
                    if (!decimal.TryParse(Console.ReadLine(), out rate))
                    {
                        Console.WriteLine("Некорректный курс.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    return;
            }

            Console.WriteLine("Выберите направление конвертации:");
            Console.WriteLine("1. Рубли в валюту");
            Console.WriteLine("2. Валюту в рубли");
            Console.Write("Ваш выбор: ");
            string dir = Console.ReadLine();

            if (dir == "1")
            {
                Console.WriteLine("Введите сумму в рублях:");
                if (decimal.TryParse(Console.ReadLine(), out decimal rubles))
                {
                    decimal converted = rubles / rate;
                    Console.WriteLine($"{rubles} руб = {converted:F2} единиц валюты");
                }
                else
                {
                    Console.WriteLine("Некорректная сумма.");
                }
            }
            else if (dir == "2")
            {
                Console.WriteLine("Введите сумму в валюте:");
                if (decimal.TryParse(Console.ReadLine(), out decimal currencyAmount))
                {
                    decimal converted = currencyAmount * rate;
                    Console.WriteLine($"{currencyAmount} единиц валюты = {converted:F2} руб");
                }
                else
                {
                    Console.WriteLine("Некорректная сумма.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }

        static void SearchByName()
        {
            Console.WriteLine("Введите название услуги или товара для поиска:");
            string searchTerm = Console.ReadLine().ToLower();

            var results = expenses.FindAll(e => e.Name.ToLower().Contains(searchTerm));

            if (results.Count == 0)
            {
                Console.WriteLine("Совпадений не найдено.");
            }
            else
            {
                Console.WriteLine("Найденные траты:");
                foreach (var expense in results)
                {
                    Console.WriteLine($"- {expense.Name}: {expense.Amount} руб");
                }
            }
        }
    }
}
