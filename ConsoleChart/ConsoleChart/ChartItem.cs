using System;

namespace ConsoleChart
{
    public class ChartItem
    {
        private string _text;

        public ChartItem(string text, int value)
        {
            _text = text;
            Value = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Value { get; set; }
    }
}