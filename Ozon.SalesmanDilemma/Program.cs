using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.SalesmanDilemma
{
    public class Program
    {
        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                Console.WriteLine(HandleBuyers(line.Split(' ').Select(x => int.Parse(x)).ToArray()));
        }

        private static bool HandleBuyers(int[] buyers)
        {
            var two = new List<int>();
            var one = new List<int>();

            for (int i = 0; i < buyers.Length; i++)
            {
                if (buyers[i] == 1000)
                { 
                    one.Add(1000);
                }
                else if (buyers[i] == 2000)
                {
                    if (one.Count >= 1)
                    {
                        one.Remove(1000);
                        two.Add(2000);
                    }
                    else return false;
                }
                else if (buyers[i] == 5000)
                {
                    var feeMoney = 0;

                    while (feeMoney != 4000)
                    {
                        if (two.Count == 0 && one.Count == 0) return false;
                        else if (two.Count != 0 && two.Remove(2000)) feeMoney += 2000;
                        else if (one.Remove(1000)) feeMoney += 1000;
                    }
                }
            }

            return true;
        }
    }
}

/*------------------------------ДИЛЕММА ПРОДАВЦА------------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условия:
        Вышла новая редакция книги CLR via C#, и в книжных магазинах начался ажиотаж,
        выстроились огромные очереди из желающих ее купить.
        У каждого человека есть на руках купюры номиналом 1000, 2000, 5000 рублей.
        При этом книга стоит 1000 рублей.
        В начале рабочего дня в кассе у продавца нет денег на сдачу. 
        Необходимо написать функцию, которая принимает коллекцию из значений номиналов купюр,
        которые передают покупатели продавцу за книгу, и которая на основе этого определяет,
        сможет ли продавец продать книги и дать сдачу всем покупателям. Возвращает ответ True или False.
        Порядок покупателей строго учитывается.
        Результат выполнения надо вывести в стандартный вывод. 
 
-----Формат входных данных:
        Строка, в которой содержатся номиналы купюр, разделенные пробелами.
 
-----Формат выходных данных:
        Строка, либо "True", либо "False".

-----Примеры:
        Входные данные:  1000 2000 1000 2000 5000
        Выходные данные: True
 *///---------------------------------------------------------------------------