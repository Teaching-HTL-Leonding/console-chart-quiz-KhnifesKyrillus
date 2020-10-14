using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChart
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Arguments are not correct!");
                return;
            }

            List<ChartItem> items = new List<ChartItem>();

            string line = Console.ReadLine();

            string[] categories = line.Split('\t');
            var textIndex = Array.IndexOf(categories, args[0]);
            var valueIndex = Array.IndexOf(categories, args[1]);
            line = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrEmpty(line)) break;

                var value = 0;
                if (textIndex < line.Split('\t').Length && valueIndex < line.Split('\t').Length)
                    value = int.Parse(line.Split('\t')[valueIndex]);

                items.Add(new ChartItem(line.Split('\t')[textIndex], value)
                );
                line = Console.ReadLine();
            }

            if (items.Count < 1) return;
            ChartController controller = args.Length == 3
                ? new ChartController(int.Parse(args[2]))
                : new ChartController();

            controller.Print(items.GroupBy(d => d.Text));
        }
    }
}