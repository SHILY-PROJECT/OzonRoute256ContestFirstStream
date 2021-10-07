using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.EvaluatingBooleanExpression
{
    public class Program
    {
        [ThreadStatic]
        private static Dictionary<string, bool> _variableMap = new Dictionary<string, bool>();

        public static void Main()
        {
            string line;

            if (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var expression = line.Split(' ')[0];
                var dataVariables = line.Split(' ').Skip(1).ToArray();

                for (int i = 0; i < dataVariables.Length; i += 2)
                    _variableMap.Add(dataVariables[i], bool.Parse(dataVariables[i + 1]));

                Console.WriteLine(ProcessOperations(expression));
            }
        }

        private static bool ProcessOperations(string expression)
        {
            var operations = new List<(bool value, char operation)>();

            for (int i = 0; i < expression.Length;)
            {
                if (char.IsLetter(expression[i]))
                {
                    char operation;

                    var startIndex = i;
                    while (i < expression.Length && char.IsLetter(expression[i])) i++;
                    var endIndex = i;
                    var variable = _variableMap[expression.Substring(startIndex, endIndex - startIndex)];

                    if ((startIndex - 1) >= 0 && expression[startIndex - 1] == '!') variable = !variable;
                    if (i < expression.Length && expression[i] != '!') operation = expression[i];
                    else operation = default;

                    operations.Add((variable, operation));
                }
                else i++;
            }

            for (int i = 0; i < operations.Count;)
                if (operations[i].operation == '&')
                {
                    operations[i] = (operations[i].value && operations[i + 1].value, operations[i + 1].operation);
                    operations.RemoveAt(i + 1);
                }
                else i++;

            for (int i = 0; i < operations.Count;)
                if (operations[i].operation == '|')
                {
                    operations[i] = (operations[i].value || operations[i + 1].value, operations[i + 1].operation);
                    operations.RemoveAt(i + 1);
                }
                else i++;

            for (int i = 0; i < operations.Count;)
                if (operations[i].operation == '=')
                {
                    operations[i] = (operations[i].value == operations[i + 1].value, operations[i + 1].operation);
                    operations.RemoveAt(i + 1);
                }
                else i++;

            return operations.First().value;
        }
    }
}

/*-----------------------ВЫЧИСЛЕНИЕ ЛОГИЧЕСКОГО ВЫРАЖЕНИЯ-------------------------
-----Ограничения:
        по времени: 2 сек
        по памяти:  128 МБ

-----Условия:
        На стандартный вход подается логическое выражение и его булевы значения, необходимо вернуть результат самого логического выражения. 
        Список возможных логических операторов:

        & - логическое И 
        | - логическое ИЛИ 
        ! - отрицание 
        = - эквивалентность

        Приоритет операторов соответствует стандартным приоритетам алгебры логики.
        Результат вернуть на стандартный вывод.
 
-----Формат входных данных:
        Строка, содержащая логическое выражение, перечисление операндов и их значения, разделенные пробелом.
 
-----Формат выходных данных:
        Строка, либо "False", либо "True"

-----Примеры:
        Входные данные:  a&b|c=d&!a a True b False c True d True
        Выходные данные: False
 *///---------------------------------------------------------------------------