using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ChartItem> items = new List<ChartItem>();
            string line = Console.ReadLine();
            line = Console.ReadLine();
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
            if (args.Length == 3)
            {
                controller = new ChartController(int.Parse(args[2]));
            }
            else
            {
                controller = new ChartController();
            }

            if (args[0] == "country")
            {
                controller.Print(items.GroupBy(d => d.Country));
            }
            else if (args[0] == "animal")
            {
                controller.Print(items.GroupBy(d => d.Animal));
            }
            else if (args[0] == "time_of_day")
            {
                controller.Print(items.GroupBy(d => d.DayTime));
            }
            else
            {
                Console.Error.WriteLine("Arguments not correct!");
            }
        }
    }
}