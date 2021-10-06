using System;
using System.Linq;

namespace Ozon.CapitalizedWords
{
    public class Program
    {
        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                Console.WriteLine(string.Join(" ", line.Split(' ')
                    .Select(x => new string(x.ToLower().Select((value, index) => index == 0 ? char.ToUpper(value) : value).ToArray()))));
        }
    }
}

/*------------------------------СЛОВА С ПРОПИСНОЙ БУКВЫ------------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условие:
        На стандартный вход подается строка, содержащая слова, разделенные пробелами.
        Необходимо сделать заглавной буквой начало каждого слова в строке.
        Вывести на стандартный вывод.

-----Формат входных данных:
        Строка

-----Формат выходных данных:
        Строка

-----Примеры:
        Входные данные:  hEllo world! 
        Выходные данные: Hello World!
 *///---------------------------------------------------------------------------------