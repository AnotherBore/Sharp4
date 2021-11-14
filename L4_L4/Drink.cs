using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_L4
{
    public class Drink
    {
        private int volume;
    }
    public enum JuiceType { apple, orange, pineapple };
    public enum SodaType { coke, pepsi, fanta }
    public enum AlcoholType { whiskey, wine, beer };
    public class Juice : Drink
    {
        JuiceType type = JuiceType.apple;
        bool withPulp = false;
    }
    class Soda : Drink
    {
        SodaType type = SodaType.coke;
        int countOfBubbles = 0;
    }
    class Alcohol : Drink
    {
        AlcoholType type = AlcoholType.wine;
        int strength = 0;
    }
}
