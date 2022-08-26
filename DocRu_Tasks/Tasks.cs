namespace DocRu_Tasks;

/// <summary>
/// Реализует функции из тестового задания на вакансию "Программист-разработчик"
/// от IT-компании Док.Ру.
/// </summary>
internal static class Tasks
{
    /// <summary>
    /// Принимает в качестве аргумента натуральное число и вычисляет сумму цифр этого
    /// числа. Если полученное число имеет больше одной цифры, действие повторяется до
    /// тех пор, пока не останется одна цифра, затем возвращает полученное число.
    /// </summary>
    /// <param name="number">Натуральное число.</param>
    /// <returns>Сумму цифр натурального числа.</returns>
    /// <exception cref="ArgumentException">Переданное число не является натуральным.</exception>
    public static int GetTask4Result(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException($"Переданное число '{number}' не является натуральным.");
        }

        while (number.ToString().Length > 1)
        {
            number = number.ToString()
                .Select(p => int.Parse(p.ToString()))
                .Sum();
        }

        return number;
    }

    /// <summary>
    /// Принимает в качестве аргумента количество американских центов и формирует словарь,
    /// который показывает наименьшее количество монет используемых для создания этой суммы.
    /// </summary>
    /// <param name="number">Количество американских центов.</param>
    /// <returns>Словарь монет и их количество.</returns>
    public static IReadOnlyDictionary<string, int> GetTask5Result(double number)
    {  
        Dictionary<string, int> coins = new()
        {
            { "Quarters", 25 },
            { "Dimes", 10 },
            { "Nickels", 5 },
            { "Pennies", 1 }
        };
        var result = coins
            .Select(p => p.Key)
            .ToDictionary(p => p, p => 0);  
        int intNumber = (int)number;

        while (intNumber > 0)
        {
            foreach (var coin in coins)
            {
                if (TryAddCurrency(coin.Key, coin.Value)) break;
            }
        }

        return result;

        bool TryAddCurrency(string coinKey, int coinValue)
        {
            if (intNumber < coinValue) return false;

            intNumber -= coinValue;
            result[coinKey]++;

            return true;
        }
    }

    /// <summary>
    /// Принимает в качестве аргумента любое неотрицательное целое число, упорядочивает
    /// цифры у этого числа в порядке убывания и возвращает полученное число.
    /// </summary>
    /// <param name="number">Неотрицательное целое число.</param>
    /// <returns>Число с цифрами в порядке убывания.</returns>
    /// <exception cref="ArgumentException">Переданное число не является положительным и целым.</exception>
    public static int GetTask6Result(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"Переданное число '{number}' не является положительным и целым.");
        }

        var numberList = number.ToString()
            .Select(p => int.Parse(p.ToString()))
            .OrderByDescending(p => p)
            .ToList();

        return int.Parse(string.Join("", numberList));
    }

    /// <summary>
    ///          1
    ///        3   5
    ///      7   9   11
    ///    13  15  17  19
    ///  21  23  25  27  29
    ///  ...
    ///  
    /// Принимает в качестве аргумента индекс строки треугольника, вычисляет сумму цифр
    /// этой строки и возвращает полученное число.
    /// </summary>
    /// <param name="number">Индекс строки треугольника.</param>
    /// <returns>Сумму цифр строки треугольника.</returns>
    /// <exception cref="ArgumentException">Переданное число меньше единицы./exception>
    public static int GetTask7Result(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException($"Переданное число '{number}' меньше единицы.");
        }

        int result = number;

        for (int i = 0; i < number; i++)
        {
            result += 2 * i;
        }

        return result * number;
    }

    /// <summary>
    /// Формирует цифру 5 не используя символы из строки "0123456789*+-/".
    /// </summary>
    /// <returns>Цифру 5.</returns>
    public static int GetTask8Result() => "     ".Length;

}
