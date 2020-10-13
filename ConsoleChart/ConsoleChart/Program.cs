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
            String line = Console.ReadLine();
            String[] categories = line.Split('\t');
            int textIndex = Array.IndexOf(categories, args[0]);
            int valueIndex = Array.IndexOf(categories, args[1]);
            line = Console.ReadLine();
            while (true)
            {
                if (String.IsNullOrEmpty(line))
                {
                    break;
                }

                int value = 0;
                if (textIndex < line.Split('\t').Length && valueIndex < line.Split('\t').Length)
                {
                    value = int.Parse(line.Split('\t')[valueIndex]);
                }

                items.Add(new ChartItem(line.Split('\t')[textIndex], value)
                );
                line = Console.ReadLine();
            }

            ChartController controller = args.Length == 3
                ? new ChartController(int.Parse(args[2]))
                : new ChartController();

            controller.Print(items.GroupBy(d => d.Text));
        }
    }
}