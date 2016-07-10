using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    /// <summary>
    /// Пример работы с динамическим массивом
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            DynamicArray<int> test = new DynamicArray<int>();
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            Console.WriteLine("Добавление элемента с помощью метода Add");
            test.Add(1);
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            List<int> ints = new List<int> { 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine("Добавление списка элементов с помощью метода AddRange");
            test.AddRange(ints);
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            Console.WriteLine("Удаление элемента");
            test.Remove(3);
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            Console.WriteLine("Добавление списка элементов с помощью метода AddRange");
            test.AddRange(new List<int> { 9, 10, 11, 12, 13, 14, 15 });
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            Console.WriteLine("Добавление трех элементов с помощью методов Add.");
            test.Add(16);
            test.Add(17);
            test.Add(18);
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);
            Console.WriteLine("Добавление элемента по индексу");
            test.Insert(4, 3);
            Console.WriteLine("Length: {0}; Capacity: {1}", test.Length, test.Capacity);

            Console.WriteLine("Считываем коллекцию Enumerator-ом");
            foreach (var item in test)
                Console.WriteLine("item.Value {0}", item);

            Console.WriteLine();
            Console.WriteLine("С помощьюиндексатора присваиваем новые значения первым двум элементам.Считываем коллекцию Enumerator-ом");
            test[0] = 555;
            test[1] = 666;

            foreach (var item in test)
                Console.WriteLine("item.Value {0}", item);

            //Console.WriteLine("Добавление элемента по индексу которого не существует");
            //if (!test.Insert(1000, 20))
            //    Console.WriteLine("Ошибка добавления в коллекцию");
            test.AddRange(new DynamicArray<int> { 100, 200, 300});

            Console.ReadKey();

        }
    }
}
