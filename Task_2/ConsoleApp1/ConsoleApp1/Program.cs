using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_2\\input.txt"; // Вхідний файл
        string outputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_2\\output.txt"; // Вихідний файл

        // Зчитування тексту з файлу
        string text = File.ReadAllText(inputFilePath);

        // Видалення однобуквених слів та слів, що починаються з 'a', 'b', 'c', 'd' або 'e'
        string resultText = RemoveUnwantedWords(text);

        // Запис результату у новий файл
        File.WriteAllText(outputFilePath, resultText);

        Console.WriteLine("Обробка завершена. Результат записано у файл 'output.txt'.");
    }

    static string RemoveUnwantedWords(string text)
    {
        // Розділення тексту на слова і розділові знаки
        string[] words = Regex.Split(text, @"(\W+)");

        // Видалення непотрібних слів
        string[] unwantedWords = words.Where(word =>
            string.IsNullOrWhiteSpace(word) ||
            !(word.Length == 1 || "abcde".Contains(char.ToLower(word[0])))).ToArray();

        // Об'єднання слів назад у текст
        return string.Concat(unwantedWords);
    }
}
