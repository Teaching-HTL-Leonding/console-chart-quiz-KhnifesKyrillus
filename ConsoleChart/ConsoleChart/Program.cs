﻿using System;
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
            while (!string.IsNullOrEmpty(line))
            {
                items.Add(new ChartItem(line.Split('\t')[textIndex], int.Parse(line.Split('\t')[valueIndex]))
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