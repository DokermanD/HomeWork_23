using System.Diagnostics;

namespace HomeWork_23;

internal class Program
{
    private static void Main(string[] args)
    {
        var stopWach = new Stopwatch();

        stopWach.Start();
        GetFilesAndReadAllText(@"D:\VS-2022\HomeWork-23\HomeWork_23\HomeWork_23\bin\Debug\net6.0\testFile");
        stopWach.Stop();

        Console.WriteLine($"Затрачено времени на выполнение - {stopWach.Elapsed.Milliseconds} Milliseconds");
        Console.ReadKey();

        void GetFilesAndReadAllText(string patch)
        {
            //Получаем все пути к файлам в папке
            var filePatch = Directory.GetFiles(patch);
            var tasks = new Task[filePatch.Length];

            for (var a = 0; a < filePatch.Length; a++)
            {
                var a1 = a;
                tasks[a] = Task.Run(() =>
                {
                    var number = a1;
                    var textFile = File.ReadAllText(filePatch[number]);
                    var countSpace = textFile.Count(ch => ch == ' ');

                    Console.WriteLine($"Кол. пробелов в файле {Path.GetFileName(filePatch[number])} - {countSpace}");
                });
            }

            Task.WaitAll(tasks);
        }
    }
}