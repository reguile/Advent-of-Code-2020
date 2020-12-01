using System;
using System.IO;
using System.Collections.Generic;

namespace Day1 {
    class Program {
        static void Main(string[] args) {
            try {
                // I'm not sure if this is the best way to do this. I stuck the text file in the product directory.
                string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "input.txt");
                
                List<int> nums = new List<int>();
                
                // Read the list of numbers, standard stuff
                using (StreamReader sr = new StreamReader(path)) {
                    string line;
                    while((line = sr.ReadLine()) != null) {
                        nums.Add(Convert.ToInt32(line));
                    }                                                       
                }

                /* Instead of just manually checking every number,
                 * we sort the list and create pointers to the front and back.
                 * From there, we simply add the front and back points,
                 * determine whether the sum is above or below the target,
                 * and shift to the next highest or lowest number.
                 */ 
                nums.Sort();

                int front = 0;
                int back = nums.Count-1;
                int sum = 0;

                while(sum != 2020 && (front <= back)) {
                    sum = nums[front] + nums[back];

                    // number too small, move to a bigger number
                    if(sum < 2020) {
                        front++;
                    }
                    // number too big, move to smaller number
                    else if (sum > 2020) {
                        back--;
                    }
                }

                int product = nums[front] * nums[back];

                Console.WriteLine("{0}", product);
                Console.ReadLine();
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
