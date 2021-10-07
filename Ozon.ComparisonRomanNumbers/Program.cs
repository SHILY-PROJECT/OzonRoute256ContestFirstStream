using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.ComparisonRomanNumbers
{
    public class Program
    {
        private static readonly Dictionary<char, int> _romanMap = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var first = ConvertRomanNumeralsToInt(line.Split(' ')[0].ToCharArray());
                var last = ConvertRomanNumeralsToInt(line.Split(' ')[1].ToCharArray());

                if (first == last) Console.WriteLine(0);
                else if (first > last) Console.WriteLine(1);
                else if (first < last) Console.WriteLine(-1);
            }
        }

        private static int ConvertRomanNumeralsToInt(char[] romanNuber)
        {
            var result = 0;

            List<(char symbol, int number)> roman = romanNuber.Select(x => (x, _romanMap[x])).ToList();

            for (int i = 0; i < roman.Count; i++)
            {
                if (roman.Count <= (i + 1)) result += roman[i].number;
                else if (roman[i].number >= roman[i + 1].number) result += roman[i].number;
                else if (roman[i].number < roman[i + 1].number) result -= roman[i].number;               
            }

            return result;
        }
    }
}

/*----------------------------------СРАВНЕНИЕ РИМСКИХ ЧИСЕЛ------------------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условия:
        Необходимо написать функцию сравнения двух римских чисел,
        которая возвращает -1, если первое число меньше, чем второе;
        0, когда числа равны;
        и 1, если первое число больше, чем второе.

        Римская система счисления содержит символы: I, V, X, L, C, D и M.
        Следующие цифры римской системы счисления соответствуют символам в десятичной системе:
        I = 1; V = 5; X = 10; L = 50; C = 100; D = 500; M = 1000.

        Числа в римской системе обычно записываются от большего к меньшему, слева направо,
        например, семь можно записать как V + II = VII, а двадцать семь как XX + V + II = XXVII.
        Однако, число 4 записывается не как IIII, а как IV.
        Т.е. для получения некоторых цифр в римской системе счисления используется принцип вычитания. 
        Следующие правила задают условия, при которых следует использовать принцип вычитания:
		
        I может предшествовать V (5) и X (10) для получения 4-х и 9-и соответственно;
        X может предшествовать L (50) и С (100) для получения 40-а и 90-а соответственно;
        С может предшествовать D (500) и M (1000) для получения 400-а и 900-а соответственно.

        Результат вывести на стандартный вывод.

-----Формат входных данных:
        Строка, в которой содержатся два числа в римской форме, разделенные пробелом.
    
-----Формат выходных данных:
        Строка, либо "-1", либо "0", либо "1"

-----Примеры:
        Входные данные:  MMLXII MMLX 
        Выходные данные: 1
*///-------------------------------------------------------------------------------------------