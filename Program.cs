using System.Collections.Immutable;
using static System.Console;

namespace Home_Work_7
{
    class Program
    {
        public static void Main(string[] args)
        {
            (string, string, string)[] Search(
                string input,
                List<(string, string, string)>? collection) =>
                collection.Where(person =>
                    person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                    person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                    person.Item3.Contains(input)).ToArray();

            List<(string, string, string)>? book = null;
            // ця логіка перевіряє, чи існує файл з даними, який прописаний в методі ФайлРідер(). 
            // в цьому випадку спрацює catch, бо задано невірний шлях до файлу
            try
            {
                book = FileReader();
            }
            catch
            {
                Console.WriteLine("File doesn't exist");
                Console.ReadKey();
            }
            finally
            {
                WriteLine("Search: ");
                WriteLine($"Input abonent's name or number: ");
                var list = Search(ReadLine(), book);
                WriteLine("Search result: ");

                WriteLine(
                    $"{(list.Any() ? $"{string.Join("\r\n", list.ToImmutableSortedSet())}" : "No result with this parameters")}");
            }
        }

        

        private static List<(string Name, string Surname, string Number)>? FileReader()
        {
            var book = new List<(string Name, string Surname, string Number)>();
                                                                                     
            var lines = File.ReadAllLines("C:\\Beet_lessons\\Home_Work_7\\PhoneBook.xt");
            foreach (var line in lines)
            {
                var split = line.Split(",");
                book.Add((split[0], split[1], split[2]));
            }
            return book;
        }
    }
}