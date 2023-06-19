using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp_conversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal fahrenheit, celsius;
            string name = null, email = null, xp_level = null, country = null;

            // Get user's name
            Console.WriteLine("Please Enter Your Name...");
            while (name == null | name == "")
            {
                name = Console.ReadLine().Trim();
            }
            Console.Clear();

            // Get user's e-mail
            Console.WriteLine($"{name}, Please Enter Your Email");
            while (email == null | email == "")
            {
                email = Console.ReadLine();
                /// TODO: RegEx email 

            }
            Console.Clear();

            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("How much programming Experience do you have?\n");
                Console.WriteLine("\t1. None");
                Console.WriteLine("\t2. Beginner");
                Console.WriteLine("\t3. Intermediate");
                Console.WriteLine("\t4. Expert");
                Console.Write("\nEnter # : ");

                string input = Console.ReadLine();
                try
                {
                    int num_input = int.Parse(input);
                    if (num_input < 1 | num_input > 4)
                    {
                        throw new FormatException();
                    }
                    switch (num_input)
                    {
                        case 1:
                            valid = true;
                            xp_level = "None";
                            break;
                        case 2:
                            valid = true;
                            xp_level = "Beginner";
                            break;
                        case 3:
                            valid = true;
                            xp_level = "Intermediate";
                            break;
                        case 4:
                            valid = true;
                            xp_level = "Expert";
                            break;
                    }
                }
                catch (FormatException fEx)
                {
                    Console.Clear();
                    Console.WriteLine($"{fEx.Message}: \n{input} is not a valid selection. \nPlease enter a selection between 1-4");
                }
                catch (Exception eX)
                {
                    Console.Clear();
                    Console.WriteLine(eX.Message);
                }
            }

            // Get user's country
            Console.WriteLine("What counrty do you live in?");
            while (country == null | country == "")
            {
                country = Console.ReadLine();
            }
            Console.Clear();

        }
    }
}
