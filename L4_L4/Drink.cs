using L4_L4.Properties;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_L4
{
    public class Weather
    {
        protected int temperature = 0;
        public virtual Image GetImage()
        {
            return null;
        }
        public virtual String GetInfo()
        {
            return ($"Температура воздуха: {temperature}.");
        }
        public static Random rndm = new Random();
    }

    public class Sunny : Weather
    {
        public int distance = 0;
        bool windy = false;
        public static Sunny GenerateRandomly()
        {
            return new Sunny
            {
                temperature = rndm.Next(-40, 40), 
                windy = rndm.Next(2) == 0 
            };
        }
        public override Image GetImage()
        {
            return new Bitmap(Resources.sun);
        }
        public override String GetInfo()
        {
            return $"Температура воздуха: {temperature} C. Солнечно. Высота солнца над горизонтом:{distance} м." + (windy ? "Ветренно." : "Безветренно.");
        }
    }
    public class Rainy : Weather
    {
        public int value = 0;
        bool rainbow = false;
        bool storm = false;
        public static Rainy GenerateRandomly()
        {
            return new Rainy
            {
                value = rndm.Next(1, 250),
                rainbow = rndm.Next(2) == 0,
                storm = rndm.Next(2) == 0
            };
        }
        public override Image GetImage()
        {
            return new Bitmap(Resources.rain);
        }
        public override String GetInfo()
        {
            return $"Температура воздуха: {temperature} C.Дождь. Количество осадков {value} мм. " + (rainbow ? "Радуга. " : "Без радуги. ") + (storm ? "Гроза." : "Без грозы.");
        }
    }
    public enum SnowType {flakes, fine, snowfall}
    public class Snowy : Weather
    {
        public float height = 0;
        SnowType type = SnowType.fine;
        public static Snowy GenerateRandomly()
        {
            return new Snowy
            {
                height = rndm.Next(1, 20) / 10,
                type = (SnowType) rndm.Next(3),
            };
        }
        public override Image GetImage()
        {
            return new Bitmap(Resources.snow);
        }
        private String GetSnow()
        {
            switch (type)
            {
                case SnowType.fine:
                {
                    return "Легкий снег";
                }
                case SnowType.snowfall:
                    {
                        return "Снегопад";
                    }
                case SnowType.flakes:
                {
                        return "Снег хлопьями";
                }
                default: return null;
            }
        }
        public override String GetInfo()
        {
            return $"Температура воздуха: {temperature} C. {GetSnow()}. Высота сугробов {height} м. ";
        }
    }
}
