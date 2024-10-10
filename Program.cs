using System;
using System.IO;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.Write("Введіть назву папки: ");
string folderName = Console.ReadLine();
string folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
    Console.WriteLine($"Папку '{folderName}' створено.");
}
else
{
    Console.WriteLine($"Папка '{folderName}' вже існує.");
}

string filePath = Path.Combine(folderPath, "text.txt");
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
Directory.Delete(folderPath);
Console.WriteLine("Файл та папку видалено.");
