using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Day2 {
    public static void day2part1() {
        // I'm not sure if this is the best way to do this. I stuck the text file in the product directory.
        string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"passwords_day2.txt");

        int min = 0;
        int max = 0;
        int valid = 0;
        int count = 0;

        char letter;

        string password;
        string[] substring;

        char[] seperators = new char[] {'-', ' ', ':'};

        // Read the list of numbers, standard stuff
        using (StreamReader sr = new StreamReader(path)) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                substring = line.Split(seperators);
                min = Convert.ToInt16(substring[0]);
                max = Convert.ToInt16(substring[1]);
                letter = substring[2][0];
                password = substring[4];
                count = 0;

                for(int i=0; i<password.Length; i++) {
                    if(password[i].Equals(letter)) {
                        count++;
                    }
                }

                if(count <= max && count >= min) {
                    valid++;

                }
            }
        }

        Console.WriteLine("There are {0} valid passwords", valid);
        Console.ReadLine();
    }

    public static void day2part2() {
        // I'm not sure if this is the best way to do this. I stuck the text file in the product directory.
        string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"passwords_day2.txt");

        int pos1 = 0;
        int pos2 = 0;
        int valid = 0;

        char letter;

        string password;
        string[] substring;

        char[] seperators = new char[] { '-', ' ', ':' };

        // Read the list of numbers, standard stuff
        using (StreamReader sr = new StreamReader(path)) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                substring = line.Split(seperators);
                pos1 = Convert.ToInt16(substring[0]) - 1;
                pos2 = Convert.ToInt16(substring[1]) - 1;
                letter = substring[2][0];
                password = substring[4];

                // there's got to be a cleaner way to do this.
                if((password[pos1] == letter && password[pos2] != letter) || (password[pos1] != letter && password[pos2] == letter)) {
                    valid++;
                }


            }
        }

        Console.WriteLine("There are {0} valid passwords", valid);
        Console.ReadLine();
    }
}

