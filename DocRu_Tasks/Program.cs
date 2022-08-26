namespace DocRu_Tasks;

class Program
{
    public static void Main(string[] args)
    {
        object[] taskResults =
        {
            Tasks.GetTask4Result(164),
            Tasks.GetTask5Result(56),
            Tasks.GetTask6Result(1538604),
            Tasks.GetTask7Result(5),
            Tasks.GetTask8Result()
        };

        for (int i = 0; i < taskResults.Length; i++)
        {
            Print(i + 4, taskResults[i]);
        }

        Console.ReadKey();
    }

    private static void Print(int taskNumber, object result)
    {
        switch (result)
        {
            case IReadOnlyDictionary<string, int> dictionary:
                {
                    PrintDictionaryResult(taskNumber, dictionary);
                    break;
                }
            case int number:
                {
                    PrintNumberResult(taskNumber, number);
                    break;
                }
        }
    }

    private static void PrintNumberResult(int taskNumber, int number)
    {
        Console.WriteLine($"Задача {taskNumber}: {number}\n");
    }

    private static void PrintDictionaryResult(int taskNumber, IReadOnlyDictionary<string, int> dictionary)
    {
        var lastElement = dictionary.Last();

        Console.Write($"Задача {taskNumber}: ");

        foreach (var element in dictionary)
        {
            string comma = element.Equals(lastElement) ? "}\n\n" : ", ";

            Console.Write($"{element.Key}: {element.Value}{comma}");
        }
    }
}