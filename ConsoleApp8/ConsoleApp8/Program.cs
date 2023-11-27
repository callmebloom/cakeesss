using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static Torti.Cake;

namespace Torti
{
    internal class Program
    {
        private static int money = 0;
        private static string zakaz = "";
        static void Main()
        {
            Kakoytort heart = new Kakoytort("в виде сердечка", 300);
            Kakoytort star = new Kakoytort("в виде звездочки", 400);
            Kakoytort kitten = new Kakoytort("в виде котика", 500);
            Characteristic shape = new Characteristic();
            shape.Name = "форма";
            shape.Options = new List<Kakoytort> { heart, star, kitten };

            Kakoytort bento = new Kakoytort("маленький бенто-тортик", 500);
            Kakoytort normal = new Kakoytort("обычный нормальный торт", 800);
            Kakoytort gigant = new Kakoytort("огромный тортяра", 1500);
            Characteristic size = new Characteristic();
            size.Name = "размер";
            size.Options = new List<Kakoytort> { bento, normal, gigant };

            Kakoytort mix = new Kakoytort("земляника + ежевика + малина", 300);
            Kakoytort kinder = new Kakoytort("как киндер", 500);
            Kakoytort cheesecake = new Kakoytort("чизкейк", 300);
            Characteristic taste = new Characteristic();
            taste.Name = "вкусы";
            taste.Options = new List<Kakoytort> { mix, kinder, cheesecake };

            Kakoytort pink = new Kakoytort("розовый перламутр", 200);
            Kakoytort choco = new Kakoytort("шоколадная", 100);
            Kakoytort gradient = new Kakoytort("градиентная", 450);
            Characteristic glazur = new Characteristic();
            glazur.Name = "глазурь";
            glazur.Options = new List<Kakoytort> { pink, choco, gradient };

            Kakoytort posipca = new Kakoytort("посыпка", 150);
            Kakoytort mastika = new Kakoytort("фигурки из мастики", 200);
            Kakoytort berry = new Kakoytort("ягодки", 170);
            Characteristic decor = new Characteristic();
            decor.Name = "декор";
            decor.Options = new List<Kakoytort> { posipca, mastika, berry };

            int pos = 0;
            int pos1 = 0;
            List<Characteristic> punkts = new List<Characteristic> { shape, size, taste, glazur, decor };
            Menu(punkts, pos, pos1);
        }
        static void Menu(List<Characteristic> punkts, int pos, int pos1)
        {
            foreach (Characteristic i in punkts)
            {
                Console.WriteLine("  " + i.Name);
            }
            Console.WriteLine("  чтобы сохранить заказ наведите стрелочку на этот пункт и нажмите кнопку (Backspace)");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("итоговая цена: " + money);
            Console.WriteLine("состав вашего заказа: " + zakaz);
            Arrow(punkts, pos, pos1);
        }
        static int Arrow(List<Characteristic> punkts, int pos, int pos1)
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Console.WriteLine("ваш чек записан в отдельный файл");
                Save(money, zakaz);
            }
            else
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        pos--;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        pos++;
                    }
                    Console.Clear();
                    Menu(punkts, pos, pos1);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
            Console.Clear();
            ZakazMenu(punkts, pos, pos1);
            return pos;
        }
        static void ZakazMenu(List<Characteristic> punkts, int pos, int pos1)
        {
            foreach (Kakoytort podpunkt in punkts[pos].Options)
            {
                Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
            }
            ZakazArrow(punkts, pos, pos1);
            Menu(punkts, pos, pos1);
        }
        static int ZakazArrow(List<Characteristic> punkts, int pos, int pos1)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(4, 0);
                    foreach (Kakoytort podpunkt in punkts[pos].Options)
                    {
                        Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
                    }
                    pos1--;
                    Console.SetCursorPosition(0, pos1);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    Console.SetCursorPosition(4, 0);
                    foreach (Kakoytort podpunkt in punkts[pos].Options)
                    {
                        Console.WriteLine("\t" + podpunkt.Name + ", " + podpunkt.Price + " Рублей");
                    }
                    pos1++;
                    Console.SetCursorPosition(0, pos1);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Main();
                }
            }
            Console.Clear();
            money += punkts[pos].Options[pos1].Price;
            zakaz += punkts[pos].Options[pos1].Name + ", ";
            return pos1;
        }
        static void Save(int money, string zakaz)
        {
            DateTime date = DateTime.Now;
            string sostav = zakaz;
            string cena = money.ToString();
            File.WriteAllText("C:\\Users\\Admin\\Desktop\\Текстовый документ.txt", "\nЗаказ от " + date);
            File.AppendAllText("‪C:\\Users\\Admin\\Desktop\\Текстовый документ.txt", "\nЗаказ: " + sostav);
            File.AppendAllText("‪C: \\Users\\Admin\\Desktop\\Текстовый документ.txt", "\nЦена: " + cena);
        }
    }
}