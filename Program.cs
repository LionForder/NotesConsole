using System;

namespace Notes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите путь, куда будут сохраняться файлы:");
            Notes.Path = Console.ReadLine();
            bool ap = true;
            while (ap)
            {
                Console.WriteLine("1) Создать новый файл/произвести дозаписnь\n" +
                	"2) Просмотреть имеющиеся файлы\n" +
                	"3) Просмотреть содержимое файла\n" +
                	"4) Закрыть программу");
                int digit = Convert.ToInt32(Console.ReadLine());
                switch(digit)
                {
                    case 1:
                        Notes.Fill();
                        break;
                    case 2:
                        Notes.ShowList();
                        break;
                    case 3:
                        Notes.ShowFile();
                        break;
                    case 4:
                        ap = false;
                        break;
                }
            }
        }
    }
}
