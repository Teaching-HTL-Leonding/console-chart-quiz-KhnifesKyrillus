using System;

namespace ConsoleChart
{
    public class ChartItem
    {
        private String country;
        private String dayTime;
        private String animal;
        private int attacks;

        public ChartItem(string country, string dayTime, string animal, int attacks)
        {
            this.country = country;
            this.dayTime = dayTime;
            this.animal = animal;
            this.attacks = attacks;
        }

        public string Country
        {
            get => country;
            set => country = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string DayTime
        {
            get => dayTime;
            set => dayTime = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Animal
        {
            get => animal;
            set => animal = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Attacks
        {
            get => attacks;
            set => attacks = value;
        }
    }
}