namespace Hedgehog_colors
{
    class Program
    {
        static List<int> hedgehogs = [];
        static int meetings = 0;

        static int Main(string[] args)
        {

            InputHedgehogs("red");
            InputHedgehogs("green");
            InputHedgehogs("blue");

            Console.WriteLine($"Total Sum is {hedgehogs.Sum()}");

            if (IsOneColor())
            {
                return -1;
            }

            var targetColor = GetTargetColor();

            int firstColor = (targetColor + 1) % 3;
            int secondColor = (targetColor + 2) % 3;

            while (hedgehogs[targetColor] < hedgehogs.Sum())
            {
                if ((hedgehogs[secondColor] > 0) && hedgehogs[firstColor] > hedgehogs[secondColor])
                {
                    ShortHedgehogs(firstColor, secondColor, targetColor);
                }

                else if ((hedgehogs[firstColor] > 0) && hedgehogs[secondColor] > hedgehogs[firstColor])
                {
                    ShortHedgehogs(secondColor, firstColor, targetColor);
                }

                else if (hedgehogs[firstColor] > 0 && hedgehogs[secondColor] > 0)
                {
                    MeetingHedgehogs(firstColor, secondColor, targetColor);
                }


                else if (hedgehogs[firstColor] == 0 && hedgehogs[secondColor] > 1)
                {
                    AdditionalMeetingHedgehogs(firstColor, secondColor, targetColor);
                }

                else if (hedgehogs[firstColor] > 1 && hedgehogs[secondColor] == 0)
                {
                    AdditionalMeetingHedgehogs(secondColor, firstColor, targetColor);
                }

                else if ((hedgehogs[firstColor] == 1 && hedgehogs[secondColor] == 0) ||
                    hedgehogs[firstColor] == 0 && hedgehogs[secondColor] == 1)
                {
                    break;

                }
               
            }

            Console.WriteLine($"Total meetings is {meetings}");
            Console.WriteLine($"Total hedgehogs {hedgehogs[0]} {hedgehogs[1]} {hedgehogs[2]}");

            return meetings;

        }

        private static void MeetingHedgehogs(int first_color, int second_color, int target_color) {
            hedgehogs[first_color]--;
            hedgehogs[second_color]--;
            hedgehogs[target_color] += 2;
            meetings++;
        }

        private static void AdditionalMeetingHedgehogs(int empty_color, int exist_color, int target_color) {

            hedgehogs[exist_color]--;
            hedgehogs[target_color]--;
            hedgehogs[empty_color] += 2;
            meetings++;

        }

        private static void ShortHedgehogs(int long_color, int short_color, int target_color)
        {

            var remainder = hedgehogs[long_color] - hedgehogs[short_color];
            meetings += hedgehogs[short_color];
            hedgehogs[target_color] += hedgehogs[short_color] * 2;
            hedgehogs[long_color] = remainder;
            hedgehogs[short_color] = 0;
           
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