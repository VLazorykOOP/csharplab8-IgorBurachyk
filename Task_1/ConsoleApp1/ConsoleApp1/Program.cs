using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_1\\input.txt"; // Вхідний файл
        string outputFilePath = "D:\\University\\Третій курс\\Крос-платформне програмування\\Тести\\Lab_8\\Task_1\\output.txt"; // Вихідний файл
        string ipPattern = @"\b([0-9A-Fa-f]{1,2}\.){3}[0-9A-Fa-f]{1,2}\b";

        List<string> ipAddresses = new List<string>();

        // Зчитування тексту з файлу
        string[] lines = File.ReadAllLines(inputFilePath);

        foreach (var line in lines)
        {
            MatchCollection matches = Regex.Matches(line, ipPattern);
            foreach (Match match in matches)
            {
                string hexIp = match.Value;
                string decimalIp = ConvertHexToDecimalIp(hexIp);
                ipAddresses.Add(decimalIp);
            }
        }

        // Запис IP-адрес у новий файл
        File.WriteAllLines(outputFilePath, ipAddresses);

        // Виведення кількості знайдених IP-адрес
        Console.WriteLine($"Знайдено {ipAddresses.Count} IP-адресу.");

        // Введення параметрів для заміни або вилучення
        Console.WriteLine("Введіть IP-адресу для заміни або вилучення (у десятковому форматі) (або залиште порожнім для пропуску):");
        string targetIp = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(targetIp))
        {
            Console.WriteLine("Введіть нову IP-адресу для заміни (у десятковому форматі) (або залиште порожнім для вилучення):");
            string newIp = Console.ReadLine();

            // Заміна або вилучення IP-адрес у списку
            for (int i = 0; i < ipAddresses.Count; i++)
            {
                if (ipAddresses[i] == targetIp)
                {
                    if (string.IsNullOrWhiteSpace(newIp))
                    {
                        ipAddresses.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        ipAddresses[i] = newIp;
                    }
                }
            }

            // Запис оновленого списку IP-адрес у вихідний файл
            File.WriteAllLines(outputFilePath, ipAddresses);
        }
    }

    static string ConvertHexToDecimalIp(string hexIp)
    {
        string[] hexParts = hexIp.Split('.');
        List<int> decimalParts = new List<int>();

        foreach (var hexPart in hexParts)
        {
            decimalParts.Add(Convert.ToInt32(hexPart, 16));
        }

        return string.Join(".", decimalParts);
    }
}
