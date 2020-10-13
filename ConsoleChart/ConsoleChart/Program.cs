using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Arguments are not correct!");
                return;
            }

            List<ChartItem> items = new List<ChartItem>();
            Console.ReadLine();
            string line = Console.ReadLine();
            while (true)
            {
                if (String.IsNullOrEmpty(line))
                {
                    break;
                }

                items.Add(new ChartItem(line.Split('\t')[0], line.Split('\t')[1], line.Split('\t')[2], Int32.Parse(
                    line.Split('\t')[3])));
                line = Console.ReadLine();
            }

            ChartController controller;
            controller = args.Length == 3
                ? new ChartController(args[1], int.Parse(args[2]))
                : new ChartController(args[1]);

            switch (args[0])
            {
                case "country":
                    controller.Print(items.GroupBy(d => d.Country));
                    break;
                case "animal":
                    controller.Print(items.GroupBy(d => d.Animal));
                    break;
                case "time_of_day":
                    controller.Print(items.GroupBy(d => d.DayTime));
                    break;
                case "attacks":
                    controller.Print(items.GroupBy(d => d.Attacks.ToString()));
                    break;
                default:
                    Console.Error.WriteLine("Arguments are not correct!");
                    break;
            }
        }
    }
}