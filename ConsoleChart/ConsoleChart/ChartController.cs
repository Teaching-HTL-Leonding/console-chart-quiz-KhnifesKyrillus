using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChart
{
    public class ChartController
    {
        private int _length;

        public ChartController(int length = 0)
        {
            _length = length;
        }

        public int MaxValue { get; private set; }

        private int CalculatePercentage(int value)
        {
            return (int) Math.Round((double) value / MaxValue * 100);
        }

        public void Print(IEnumerable<IGrouping<string, ChartItem>> enumerable)
        {
            List<ChartItem> result = GroupList(enumerable);

            MaxValue = result.First().Value;
            if (_length == 0) _length = result.Count;

            var count = 0;
            foreach (ChartItem line in result)
            {
                if (count >= _length) return;
                Console.Write($"{line.Text,-70}|\t");
                PrintBlanks(line.Value);
                Console.WriteLine();
                count++;
            }
        }

        private static List<ChartItem> GroupList(IEnumerable<IGrouping<string, ChartItem>> enumerable)
        {
            List<ChartItem> result = enumerable
                .Select(
                    entry => new ChartItem(
                        entry.Key,
                        entry.Sum(e => e.Value)
                    )).OrderByDescending(r => r.Value).ToList();
            ;
            return result;
        }

        private void PrintBlanks(int value)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(new string(' ',
                CalculatePercentage(value)));

            Console.ResetColor();
        }
    }
}
