using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMenuTutorial
{
    class Program
    {
        private static Menu menu;
        static void Main(string[] args)
        {
            menu = new Menu();
            menu.Add(new MenuItem() {Function = First, ItemName = "Current date"});
            menu.Add(new MenuItem() { Function = Second, ItemName = "Current object" });
            menu.Add(new MenuItem() { Function = Print, ItemName = "Print menu" });
            menu.Add(new MenuItem() { Function = CurrentType, ItemName = "CurrentType" });
            Start();
        }

        private static void Start()
        {
            object parameter = "hehe"; //it can be set as parameter for menu if needed
            while (true)
            {
                menu.Print();
                var key = Console.ReadKey(true).Key;
                
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        menu.MoveNext();
                        break;
                    case ConsoleKey.UpArrow:
                        menu.MoveBack();
                        break;
                    case ConsoleKey.Enter:
                        menu.Invoke(parameter);
                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        continue;
                }
            }
        }

        private static void CurrentType(object obj)
        {
            Console.WriteLine(obj.GetType().ToString());
        }

        private static void Print(object obj = null)
        {
            menu.Print();
        }

        public static void First(object x)
        {
            Console.Write(DateTime.Now.ToString());
        }
        public static void Second(object x)
        {
            Console.Write(x.ToString());
        }
    }
}
