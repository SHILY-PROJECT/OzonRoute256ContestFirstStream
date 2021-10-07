using System;
using System.Net;

namespace Ozon.CountingIPByRange
{
    public class Program
    {
        [Obsolete]
        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()) && IPAddress.TryParse(line.Split(' ')[0], out IPAddress fromIp) && IPAddress.TryParse(line.Split(' ')[1], out IPAddress toIp))
                Console.WriteLine((uint)IPAddress.NetworkToHostOrder((int)toIp.Address) - (uint)IPAddress.NetworkToHostOrder((int)fromIp.Address));     
        }
    }
}

/*--------------------------КОЛИЧЕСТВО СВОБОДНЫХ IP-АДРЕСОВ---------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условия:
        Реализовать функцию, которая подсчитывает количество свободных IP-адресов,
        находящихся между двумя переданными адресами, включая первый адрес и не включая второй.
        Вывести на стандартный вывод.

-----Формат входных данных:
        Два IP-адреса в формате {ddd}.{ddd}.{ddd}.{ddd}, разделенные пробелами, где {ddd} от 0 до 255
    
-----Формат выходных данных:
        Число

-----Примеры:
        Входные данные:  10.0.0.0 10.0.0.50
        Выходные данные: 50
 *///----------------------------------------------------------------------------------