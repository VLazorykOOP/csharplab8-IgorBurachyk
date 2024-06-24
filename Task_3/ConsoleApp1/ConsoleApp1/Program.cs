using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_3\\input.txt"; // Вхідний файл
        string outputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_3\\output.txt"; // Вихідний файл

        // Зчитування тексту з файлу
        string text = File.ReadAllText(inputFilePath, Encoding.UTF8);

        // Знаходження симетричних слів
        string[] symmetricWords = FindSymmetricWords(text);

        // Запис симетричних слів у новий файл
        File.WriteAllLines(outputFilePath, symmetricWords, Encoding.UTF8);

        Console.WriteLine("Обробка завершена. Симетричні слова записано у файл 'output.txt'.");
    }

    static string[] FindSymmetricWords(string text)
    {
        // Розділення тексту на слова
        string[] words = Regex.Split(text, @"\W+");

        // Знаходження симетричних слів
        return words.Where(word => word.Length > 1 && IsSymmetric(word)).ToArray();
    }

    static bool IsSymmetric(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;

        int len = word.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (word[i] != word[len - i - 1])
                return false;
        }
        return true;
    }
}
