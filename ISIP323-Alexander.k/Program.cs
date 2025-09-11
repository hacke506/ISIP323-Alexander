using System;

class Program
{
    static void Main()
    {
        const int MinOperations = 2;
        const int MaxOperations = 40;

        int count;
        string[] names;
        double[] amounts;

        // Ввод количества операций
        do
        {
            Console.Write($"Введите количество операций ({MinOperations}-{MaxOperations}): ");
            if (!int.TryParse(Console.ReadLine(), out count) || count < MinOperations || count > MaxOperations)
            {
                Console.WriteLine("Некорректное число, попробуйте снова.");
            }
        } while (count < MinOperations || count > MaxOperations);

        // Инициализация массивов
        names = new string[count];
        amounts = new double[count];

        // Ввод данных
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите данные для операции {i + 1} ");
            string input = Console.ReadLine();

            string[] parts = input.Split(';');
            if (parts.Length != 2)
            {
                Console.WriteLine("Некорректный формат, попробуйте снова.");
                i--;
                continue;
            }

            names[i] = parts[0].Trim();

            if (!double.TryParse(parts[1].Trim(), out amounts[i]))
            {
                Console.WriteLine("Некорректная сумма, попробуйте снова.");
                i--;
            }
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Сортировка по цене ");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВсе траты:");
                    for (int i = 0; i < count; i++)
                        Console.WriteLine($"{names[i]} - {amounts[i]} руб");
                    break;

                case "2":
                    if (count == 0)
                    {
                        Console.WriteLine("Нет данных для статистики.");
                        break;
                    }
                    double sum = 0, max = amounts[0], min = amounts[0];
                    for (int i = 0; i < count; i++)
                    {
                        sum += amounts[i];
                        if (amounts[i] > max) max = amounts[i];
                        if (amounts[i] < min) min = amounts[i];
                    }
                    Console.WriteLine($"Среднее: {sum / count:F2}");
                    Console.WriteLine($"Максимальное: {max}");
                    Console.WriteLine($"Минимальное: {min}");
                    Console.WriteLine($"Сумма: {sum}");
                    break;

                case "3":
                    // пузырьковая сортировка
                    for (int i = 0; i < count - 1; i++)
                    {
                        for (int j = 0; j < count - i - 1; j++)
                        {
                            if (amounts[j] > amounts[j + 1])
                            {
                                // Меняем местами суммы
                                double tempAmount = amounts[j];
                                amounts[j] = amounts[j + 1];
                                amounts[j + 1] = tempAmount;
                                // Меняем местами названия
                                string tempName = names[j];
                                names[j] = names[j + 1];
                                names[j + 1] = tempName;
                            }
                        }
                    }
                    Console.WriteLine("Данные отсортированы по цене.");
                    break;

                case "4":
                    Console.WriteLine("Введите курс валюты (1 рубль = сколько другой валюты):");
                    if (double.TryParse(Console.ReadLine(), out double rate))
                    {
                        Console.WriteLine("Траты в другой валюте:");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{names[i]} - {amounts[i] * rate:F2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный курс.");
                    }
                    break;

                case "5":
                    Console.Write("Введите название для поиска: ");
                    string searchTerm = Console.ReadLine().ToLower();
                    bool found = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (names[i].ToLower().Contains(searchTerm))
                        {
                            Console.WriteLine($"{names[i]} - {amounts[i]} руб");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Ничего не найдено.");
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }
        Console.WriteLine("Завершение программы. Нажмите любую клавишу.");
        Console.ReadKey();
    }
}