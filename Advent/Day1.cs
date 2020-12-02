using System;
using System.IO;
using System.Collections.Generic;

public class Day1
{
    public static List<int> getSortedList(string filename) {
        // I'm not sure if this is the best way to do this. I stuck the text file in the product directory.
        string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filename);

        List<int> nums = new List<int>();

        // Read the list of numbers, standard stuff
        using (StreamReader sr = new StreamReader(path)) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                nums.Add(Convert.ToInt32(line));
            }
        }

        nums.Sort();

        return nums;
    }

    public static void Part2() {
        List<int> nums = getSortedList("input.txt");

        int middle, largest, product = 0, sum = 0;

        // Basically doing the same thing as the first part, except doing an extra iteration
        for (int smallest = 0; smallest < nums.Count - 2; smallest++) {
            middle = smallest + 1;
            largest = nums.Count - 1;

            while (sum != 2020 && (middle <= largest)) {
                sum = nums[smallest] + nums[middle] + nums[largest];

                // number too small, move to a bigger number
                if (sum < 2020) {
                    middle++;
                }
                // number too big, move to smaller number
                else if (sum > 2020) {
                    largest--;
                }
            }

            if (sum == 2020) {
                product = nums[smallest] * nums[middle] * nums[largest];
                break;
            }
        }

        Console.WriteLine("The solution to Part 2 is {0}", product);
        Console.ReadLine();

    }

    public static void Part1() {
        try {
            List<int> nums = getSortedList("input.txt");

            int smallest = 0;
            int largest = nums.Count - 1;
            int sum = 0;
            int product;

            /* Instead of just manually checking every number,
            * we sort the list and create pointers to the front and back.
            * From there, we simply add the front and back points,
            * determine whether the sum is above or below the target,
            * and shift to the next highest or lowest number.
            */
            while (sum != 2020 && (smallest <= largest)) {
                sum = nums[smallest] + nums[largest];

                // number too small, move to a bigger number
                if (sum < 2020) {
                    smallest++;
                }
                // number too big, move to smaller number
                else if (sum > 2020) {
                    largest--;
                }
            }

            product = nums[smallest] * nums[largest];

            Console.WriteLine("The solution to Part 1 is {0}", product);
            Console.ReadLine();
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

}
