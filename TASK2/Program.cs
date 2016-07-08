using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK2
{
    /// <summary>
    /// Задан английский текст. Выделить отдельные слова и для каждого посчитать частоту встречаемости.
    /// Слова, отличающиеся регистром, считать одинаковыми. В качестве разделителей считать пробел и точку.
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Dictionary<string, double> frequencyWords = new Dictionary<string, double>();
            Console.WriteLine("Введите название файла для подсчета частоты встречаемости слов");
            Console.WriteLine("Чтобы использовать файл по умолчанию нажмите Enter");
            string file = Console.ReadLine();
            if (file == String.Empty)
                file = "text.txt";
            string text = default(string);
            while (!File.Exists(file))
            {
                Console.WriteLine("Указанного файла не существует. Введите название файла");
                Console.WriteLine("Чтобы использовать файл по умолчанию нажмите Enter");
                file = Console.ReadLine();
                if (file == String.Empty)
                    file = "text.txt";
            }
            using (StreamReader reader = new StreamReader(file))
            {
               text = reader.ReadToEnd(); 
            }
            string[] words = text.Split(" .,;".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                string wordLower = word.Trim().ToLower();
                int count;
                if (dictionary.TryGetValue(wordLower, out count))
                {
                    dictionary[wordLower] += 1; 
                }
                else
                {
                    dictionary.Add(wordLower, 1);
                }
            }
            StreamWriter writer = new StreamWriter("result.txt");
            foreach (var item in dictionary)
            {
                double frequency = (double)item.Value/words.Length*100;
                frequencyWords.Add(item.Key, frequency);
                writer.WriteLine("{0, -20}:{1}%", item.Key, frequency);
            }
            writer.Close();
            Process.Start("result.txt");
            Console.ReadLine();
        }
    }
}
