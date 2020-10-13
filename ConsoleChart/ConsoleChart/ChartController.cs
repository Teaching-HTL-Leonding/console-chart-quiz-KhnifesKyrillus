using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChart
{
    public class ChartController
    {
        private int length;

        public ChartController(int length = 0)
        {
            this.length = length;
        }

        public int MaxValue { get; private set; }

        private int CalculatePercentage(int value)
        {
            return (int) Math.Round((double) value / MaxValue * 100);
        }

        public void Print(IEnumerable<IGrouping<string, ChartItem>> enumerable)
        {
            var result = enumerable
                .Select(
                    g => new
                    {
                        g.Key,
                        Value = g.Sum(s => s.Value)
                    }).ToList();

            result = result.OrderByDescending(r => r.Value).ToList();
            MaxValue = result.First().Value;
            if (length == 0) length = result.Count;

            var count = 0;
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
            for (var i = 0; i < CalculatePercentage(value); i++) Console.Write(" ");

            Console.ResetColor();
        }
    }
}