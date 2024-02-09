﻿namespace Hedgehog_colors
{
    class Program
    {
        static List<int> hedgehogs = [];

        static int Main(string[] args)
        {

            InputHedgehogs("red");
            InputHedgehogs("green");
            InputHedgehogs("blue");

            if (IsOneColor())
            {
                return -1;
            }

            var targetColor = GetTargetColor();

            int meetings = 0;
            int firstColor = (targetColor + 1) % 3;
            int secondColor = (targetColor + 2) % 3;

            while (hedgehogs[targetColor] < hedgehogs.Sum())
            {


                if (hedgehogs[firstColor] > 0 && hedgehogs[secondColor] > 0)
                {
                    hedgehogs[firstColor]--;
                    hedgehogs[secondColor]--;
                    hedgehogs[targetColor] += 2;
                }
                else if (hedgehogs[firstColor] == 0 && hedgehogs[secondColor] > 1)
                {

                    hedgehogs[secondColor]--;
                    hedgehogs[targetColor]--;
                    hedgehogs[firstColor] += 2;
                }

                else if (hedgehogs[firstColor] > 1 && hedgehogs[secondColor] == 0)
                {
                    hedgehogs[firstColor]--;
                    hedgehogs[targetColor]--;
                    hedgehogs[secondColor]++;
                }

                else if ((hedgehogs[firstColor] == 1 && hedgehogs[secondColor] == 0) ||
                    hedgehogs[firstColor] == 0 && hedgehogs[secondColor] == 1)
                {
                    break;

                }
                meetings++;

            }

            Console.WriteLine($"Total meetings is {meetings}");
            Console.WriteLine($"Total hedgehogs {hedgehogs[0]} {hedgehogs[1]} {hedgehogs[2]}");

            return meetings;

        }

        private static int GetTargetColor()
        {

            while (true)
            {
                Console.WriteLine("Enter target color: 0 (Red) 1 (Green) 2 (Blue)");
                var target = Convert.ToInt32(Console.ReadLine());
                if (target >= 0 && target <= 2)
                {
                    return target;
                }

            }

        }


        private static void InputHedgehogs(string color)
        {

            var entered = false;

            while (!entered)
            {

                Console.WriteLine($"Enter a count of {color} Hedgehogs");

                var str_count = Console.ReadLine();

                if (str_count != null)
                {
                    try
                    {
                        var count = int.Parse(str_count);

                        if (count >= 0 && count <= int.MaxValue)
                        {
                            hedgehogs.Add(count);
                            entered = true;
                        }
                        else
                        {
                            Console.WriteLine("The value must be between 0 and 2147483647");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error type");
                    }

                }

            }
        }

        private static bool IsOneColor()
        {

            if ((hedgehogs[0] == 0 && hedgehogs[1] == 0) ||
                (hedgehogs[1] == 0 && hedgehogs[2] == 0) ||
                (hedgehogs[0] == 0 && hedgehogs[2] == 0) ||
                (hedgehogs.Sum() == 0))
            {
                return true;
            }

            return false;

        }

    }
}