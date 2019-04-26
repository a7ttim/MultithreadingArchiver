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
        /// Первый параметр - режим работы архиватора
        /// c или compress - сжатие
        /// u или unpack - деархивация
        /// Второй параметр - исходный файл
        /// 
        /// Третий параметр - исходный файл
        /// </param>
        static void Main(string[] args)
        {

            // Проверка на то, что файлы уже не сжаты
            try
            {
#if DEBUG
                string mode = "unpack";
                string open_path = @"ReShade_Setup_4.2.1.exe.gz";
                string save_path = @"C:\Users\A7tti\source\repos\Multithreading\Multithreading\bin\Debug\";
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
                ArchiverTaskFactory factory = new ArchiverTaskFactory();
                if (mode == "c" || mode == "compress")
                {
                    // Контейнеры для описаний файлов
                    open = new FileDescriptor(open_path);
                    save = new FileDescriptor(save_path + open.GetDescription.Name + ".gz");

                    if (!Directory.Exists(save_path))
                    {
                        throw new Exception("Dir is not exist");
                    }
                    if (open.GetDescription.Extension == ".gz")
                    {
                        throw new Exception("Source file extension is GZip");
                    }

                    Compressor progamMode = new Compressor(factory, 65536, Environment.ProcessorCount, 5000);

                    // Запуск сжатия или распаковки
                    progamMode.ProcessFile(open, save);

                    // Вывести уровень сжатия
                    Console.WriteLine("Compression level: " + Math.Truncate(save.GetDescription.Length / (double)open.GetDescription.Length * 100) + "%");
                }
                else if(mode == "u" || mode == "unpack")
                {
                    // Контейнеры для описаний файлов
                    open = new FileDescriptor(open_path);
                    save = new FileDescriptor(save_path + open.GetDescription.Name.Replace(".gz", ""));

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

                    Unzipper progamMode = new Unzipper(factory, 65536, Environment.ProcessorCount);
                    progamMode.ProcessFile(open, save);
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
