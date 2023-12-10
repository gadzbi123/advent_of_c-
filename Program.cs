
using System.Text.RegularExpressions;
using System.Reflection;

namespace First
{

    class Program
    {

        public static void Main(string[] args)
        {
            task1();
            task2();
        }
        public static void task1()
        {
            string[] lines = File.ReadAllText("./data/file1_1.txt").Split("\r\n");
            int sum = 0;
            foreach (string str in lines)
            {
                int firstNum = -1, lastNum = -1;
                foreach (char c in str)
                {
                    if (!char.IsDigit(c))
                    {
                        continue;
                    }
                    if (firstNum == -1)
                    {
                        firstNum = int.Parse(c.ToString());
                    }
                    lastNum = int.Parse(c.ToString());
                }
                sum += firstNum * 10 + lastNum;
            }
            Console.WriteLine(sum);
        }
        public static class Digits
        {
            public static readonly int One = 1;
            public static readonly int Two = 2;
            public static readonly int Three = 3;
            public static readonly int Four = 4;
            public static readonly int Five = 5;
            public static readonly int Six = 6;
            public static readonly int Seven = 7;
            public static readonly int Eight = 8;
            public static readonly int Nine = 9;
        }
        // enum Digits
        // {
        //     one, two, three, four, five, six, seven, eight, nine, ten
        // }
        class Number
        {
            public int value;
            public int position;
        }
        public static void task2()
        {
            string[] lines = File.ReadAllText("./data/file1_2.txt").Split("\r\n");
            int sum = 0;
            foreach (string str in lines)
            {
                var digits_word = string.Join("|", typeof(Digits).GetFields(BindingFlags.Public | BindingFlags.Static).Select(field => field.Name));
                var digits = $@"{digits_word}|\d+";
                MatchCollection matches = Regex.Matches(str, digits);
                foreach (Match m in matches)
                {
                    Console.WriteLine($"{m}");
                }

            }
        }
    }
}