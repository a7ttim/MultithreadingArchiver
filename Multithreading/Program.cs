using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Multithreading
{
    class Program
    {
        /// <summary>
        /// Конструктор класса Распаковки
        /// </summary>
        /// <param name="args">
        /// Первый параметр - режим работы архиватора:
        /// c или compress - сжатие /
        /// u или unpack - деархивация;
        /// Второй параметр - исходный файл;
        /// Третий параметр - конечный файл
        /// </param>
        static void Main(string[] args)
        {
            /// TODO:
            /// Генерацию исключений в Program переместить в отдельные методы

            // Проверка на то, что файлы уже не сжаты
            try
            {
#if DEBUG
                string mode = "compress";
                string open_path = @"ReShade_Setup_4.2.1.exe";
                string save_path = @"C:\Users\A7tti\source\repos\MultithreadingArchiver\Multithreading\bin\Debug\";
#else
                if (args.Length < 2)
                {
                    throw new Exception("Unable command line arguments");
                }

                string mode = args[0];
                string open_path = args[1];
                string save_path = args[2];           
#endif
                // Контейнеры для описаний файлов
                FileDescriptor open;
                FileDescriptor save;
                // Инициализация
                if (mode == "c" || mode == "compress")
                {
                    // Контейнеры для описаний файлов
                    open = new FileDescriptor(open_path);
                    save = new FileDescriptor(save_path + open.GetDescription.Name + ".gz");

                    // Обработка исключений
                    if (!File.Exists(open_path))
                    {
                        throw new Exception("Source file is not exist");
                    }
                    if (open.GetDescription.Extension == ".gz")
                    {
                        throw new Exception("Source file extension is GZip");
                    }
                    if (!Directory.Exists(save_path))
                    {
                        throw new Exception("Dir is not exist");
                    }

                    CompressionTaskFactory factory = new CompressionTaskFactory();
                    Compressor progamMode = new Compressor(factory, 65536, Environment.ProcessorCount, 100);

                    var timer = new Stopwatch();
                    timer.Start();

                    // Запуск сжатия
                    if (!progamMode.ProcessFile(open, save))
                    {
                        throw new Exception("Unsuccesful compressing");
                    }

                    timer.Stop();

                    Console.WriteLine(timer.Elapsed.TotalSeconds);
                    Console.ReadLine();

                    // Вывести уровень сжатия
                    Console.WriteLine("Compression level: " + Math.Truncate(save.GetDescription.Length / (double)open.GetDescription.Length * 100) + "%");
                }
                else if(mode == "u" || mode == "unpack")
                {
                    // Контейнеры для описаний файлов
                    open = new FileDescriptor(open_path);
                    save = new FileDescriptor(save_path + open.GetDescription.Name.Replace(".gz", ""));

                    // Обработка исключений
                    if (!File.Exists(open_path))
                    {
                        throw new Exception("Source file is not exist");
                    }
                    if (!Directory.Exists(save_path))
                    {
                        throw new Exception("Dir is not exist");
                    }
                    if (save.GetDescription.DirectoryName == ".gz")
                    {
                        throw new Exception("Destination file extension is GZip");
                    }
                    if (open.GetDescription.Extension != ".gz")
                    {
                        throw new Exception("Source file extension is not GZip");
                    }

                    UnzipperTaskFactory factory = new UnzipperTaskFactory();
                    Unzipper progamMode = new Unzipper(factory, Environment.ProcessorCount);

                    var timer = new Stopwatch();
                    timer.Start();

                    // Запуск распаковки
                    if (!progamMode.ProcessFile(open, save))
                    {
                        throw new Exception("Unsuccesful unpacking");
                    }

                    timer.Stop();

                    Console.WriteLine(timer.Elapsed.TotalSeconds);
                    Console.ReadLine();
                }                
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                Console.ReadKey();
            }
        }
    }
}
