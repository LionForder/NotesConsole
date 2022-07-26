using System;
using System.IO;
using System.Text;

namespace Notes
{
    public static class Notes
    {
        public static string Path { get; set; } = "";
        static public DateTime Date { get; set; }

        public static void Fill()
        {
            string all, zero = "0";
            FillDate(out string day, out string month, out string year);

            all = $"{year},{month},{day}";
             Date = Convert.ToDateTime(all);
            // если на такую дату нет заметок, создать файл и внести заметку
            using (var sw = new StreamWriter($"{Path}{(day.Length > 1 ? day : zero + day)}" +
                $"_{(month.Length > 1 ? month : zero + month)}" +
                $"_{year}.txt", true, Encoding.UTF8))   // позволяет создать объект внутри блока кода и при выходе
                                                        // за скобки, объект будет уничтожен с помощью метода Dispose
            {
                Console.WriteLine("Введи 'стоп', чтобы закончить вводить, иначе вводи через энтер дела");
                string content = Console.ReadLine();
                string text;

                using (var sr = new StreamReader($"{Path}{(day.Length > 1 ? day : zero + day)}" +
                $"_{(month.Length > 1 ? month : zero + month)}" +
                $"_{year}.txt"))
                {
                    text = sr.ReadToEnd();
                }

                string[] splitText = text.Length > 0 ? text.Split(';') : null;
                // int counter = text.Length > 0 ? Convert.ToInt32(splitText[splitText.Length - 2]) : 1;

                int counter = 1;
                if (text.Length > 0)
                    counter = Convert.ToInt32(splitText[splitText.Length - 2].Split(')')[0]) + 1;
                else counter = 1;

                while (content.ToLower() != "стоп")
                {
                    sw.WriteLine($"{counter}) {content.Substring(0, 1).ToUpper() + content.Substring(1)};");
                    counter++;
                    content = Console.ReadLine();

                }
                Console.WriteLine();
            }
        }


        public static void ShowFile()
        {
            ShowList();
            int num = Convert.ToInt32(Console.ReadLine());
            using (var sr = new StreamReader(Directory.GetFiles(Path)[num - 1]))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }


        public static void ShowList()
        {
            Console.WriteLine("Проекты:\n");
            for (int i = 0; i < Directory.GetFiles(Path).Length; i++)
                Console.WriteLine($"{i + 1}) {Directory.GetFiles(Path)[i]}");
            Console.WriteLine();
        }


        public static void FillDate(out string day, out string month, out string year)
        {
            Console.Write("Введи день, месяц и год:\nДень:");
            day = Console.ReadLine();
            Console.Write("Месяц:");
            month = Console.ReadLine();
            Console.Write("Год:");
            year = Console.ReadLine();
        }

        /*
        public static void Delete()
        {
            Console.WriteLine("Нужно удалить файл или удалить строку в файле?\n1)файл\n2)строку");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (number)
            {
                case 1:
                    ShowList();
                    int num = Convert.ToInt32(Console.ReadLine());
                    if(File.Exists(Directory.GetFiles(Path)[num - 1]))
                        File.Move(Directory.GetFiles(Path)[num - 1], "trash:///"); // третий параметр - TRUE (можно ли перезаписывать файл)
                        // if (File.Exists(Directory.GetFiles(Path)[num - 1]))
                        //     File.Delete(Directory.GetFiles(Path)[num - 1]);
                    break; 
                case 2:
                    using (var sr = new StreamReader(Path))
                    {
                    }
                    break;
                default:
                    {
                        break;
                    }
            }
            using (var sr = new StreamReader(Path))
            {
            }
        }
        */
    }
}
