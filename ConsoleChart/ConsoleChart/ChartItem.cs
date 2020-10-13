using System;

namespace ConsoleChart
{
    public class ChartItem
    {
        private String text;
        private int value;

        public ChartItem(string text, int value)
        {
            this.text = text;
            this.value = value;
        }

        public string Text
        {
            get => text;
            set => text = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Value
        {
            get => value;
            set => this.value = value;
        }
    }
}