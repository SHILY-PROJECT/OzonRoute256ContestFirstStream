using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.CountingCharacters
{
    public class Program
    {
        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var dataSymbol = new List<(char symbol, int count)>();
                
                for (int i = 0; i < line.Length; i++)
                    dataSymbol.Add((line[i], dataSymbol.Count(x => x.symbol == line[i]) + 1));

                Console.WriteLine(string.Join("", dataSymbol.Select(x => x.count).ToArray()));
            }
        }
    }
}

/*-----------------------------------ПОДСЧЕТ СИМВОЛОВ----------------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условия:
        На стандартный вход подается строка. 
        Нужно написать функцию, которая на вход принимает строку, а на выходе мы получаем строку, состоящую из цифр, которые соответствуют правилу: 
        Если текущий символ ни разу еще не встречался, то пишем 1, если он уже встречался ранее, то записываем сколько раз он уже встречался 
        Вывести на стандартный вывод.

-----Формат входных данных:
        Строка

-----Формат выходных данных:
        Строка, состоящая из цифр

-----Примеры:
        Входные данные:  Привет мир!
        Выходные данные: 11111111221
 *///----------------------------------------------------------------------------------
