using System;

namespace ConsoleChart
{
    public class ChartItem
    {
        private string text;

        public ChartItem(string text, int value)
        {
            this.text = text;
            Value = value;
        }

        public string Text
        {
            get => text;
            set => text = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Value { get; set; }
    }
}