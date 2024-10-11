using System;
using System.IO;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.Write("Введіть назву папки: ");
string name = Console.ReadLine();
string path = @"D:\Visual Studio\ConsoleApp19\ConsoleApp19";

if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
    Console.WriteLine($"Папку '{name}' створено.");
}
else
{
    Console.WriteLine($"Папка '{name}' вже існує.");
}

string filePath = Path.Combine(path, "text.txt");
string[] lines = new string[5];

for (int i = 0; i < 5; i++)
{
    Console.Write($"Введіть рядок {i + 1}: ");
    lines[i] = Console.ReadLine();
}

await File.WriteAllLinesAsync(filePath, lines);
Console.WriteLine("Текст записано у файл 'text.txt'.");

string[] fileContent = await File.ReadAllLinesAsync(filePath);
for (int i = 0; i < fileContent.Length; i++)
{
    Console.WriteLine($"Рядок {i + 1}: {fileContent[i]} (Кількість символів: {fileContent[i].Length})");
}

File.Delete(filePath);
Directory.Delete(path);
Console.WriteLine("Файл та папку видалено.");
