using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK1
{
    class Program
    {
        /// <summary>
        /// В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета по кругу вычеркивается
        /// каждый второй человек, пока не останется один. Составить программу, моделирующую процесс.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите количество людей в кругу");
                string N = Console.ReadLine();
                int count;
                if (Int32.TryParse(N, out count))
                {
                    LinkedList<int> list = new LinkedList<int>();
                    for (var i = 1; i <= count; i++)
                    {
                        list.AddLast(i);
                    }
                    Console.WriteLine("В кругу {0} человек", list.Count);

                     while (list.Count != 1)
                        {
                            var currentItem = list.First;
                            while (currentItem != null && currentItem.Next != null)
                            {
                                Console.WriteLine("Удаляется: {0}", currentItem.Next.Value);
                                list.Remove(currentItem.Next);
                                currentItem = currentItem.Next;
                            }
                        }
                    Console.WriteLine("Остался 1 элемент {0}", list.First.Value);

                }
                else
                {
                    Console.WriteLine("Ошибка: Не верно введенное значение");
                    Console.WriteLine();
                }
            }
            
        }
    }
}
