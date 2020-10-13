using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace ConsoleChart
{
    public class ChartController
    {
        private int maxValue;
        private int length;

        public ChartController(int length = 0)
        {
            this.length = length;
        }

        public int MaxValue
        {
            get => maxValue;
        }

        private int CalculatePercentage(int value)
        {
            return (int) Math.Round(((double) value / maxValue) * 100);
        }

        public void Print(IEnumerable<IGrouping<string, ChartItem>> enumerable)
        {
            var result = enumerable
                .Select(
                    g => new
                    {
                        Key = g.Key,
                        Value = g.Sum(s => s.Value),
                    }).ToList();

            result = result.OrderByDescending(r => r.Value).ToList();
            this.maxValue = result.First().Value;
            if (length == 0)
            {
                length = result.Count;
            }

            int count = 0;
            foreach (var line in result)
            {
                if (count >= length) return;
                Console.Write($"{line.Key,-70}|\t");
                PrintBlanks(line.Value);
                Console.WriteLine();
                count++;
            }
        }

        private void PrintBlanks(int value)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < CalculatePercentage(value); i++)
            {
                Console.Write(" ");
            }

            Console.ResetColor();
        }
    }
}