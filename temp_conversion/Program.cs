using ClassLibrary;
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
            string name = null, email = "", xp_level = null, country = null;

            // Get user's name
            Console.WriteLine("Please Enter Your Name...");
            while (name == null | name == "")
            {
                name = Console.ReadLine().Trim();
            }

            // Get user's e-mail
            bool valid_email = false;
            while (!valid_email)
            {
                Console.Clear();
                Console.WriteLine($"{name}, Please Enter Your Email");
                email = Console.ReadLine();
                valid_email = MethodLibrary.ValidateEmail(email.Trim());
                if (!valid_email)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Email! Press any key to try again");
                    Console.ReadKey(false);
                }
            }

            bool valid = false;
            while (!valid)
            {
                Console.Clear();

                Console.WriteLine("How much programming Experience do you have?\n");
                Console.WriteLine("\t1. None");
                Console.WriteLine("\t2. Beginner");
                Console.WriteLine("\t3. Intermediate");
                Console.WriteLine("\t4. Expert");
                Console.Write("\nEnter # : ");
                string input = "";

                try
                {
                    input = Console.ReadLine();
                    if (input == null | input == "")
                    {
                        throw new Exception("Something went wrong!! Press any key to try again...");
                    }

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
                    Console.WriteLine($"{fEx.Message}: \n{input} is not a valid selection. \nPlease enter a selection between 1-4 \nPress any key to try again..");
                    Console.ReadKey(false);
                }
                catch (Exception eX)
                {
                    Console.Clear();
                    Console.WriteLine(eX.Message);
                    Console.ReadKey(false);
                }
            }

            // Get user's country
            while (country == null | country == "")
            {
                Console.Clear();
                Console.WriteLine("What country do you live in?");
                country = Console.ReadLine();
            }

            // Choose Fahrenheit to Celsuis or Celsius to Fahrenheit
            string user_choice = "";
            bool valid_choice = false;
            while (!valid_choice)
            {
                Console.Clear();
                Console.WriteLine("Would you like to convert Fahrenheit to Celsius or Celsius to Fahrenheit?");
                Console.WriteLine("\t1. Fahrenheit to Celsius");
                Console.WriteLine("\t2. Celsius to Fehrenheit");
                try
                {
                    user_choice = Console.ReadLine();
                    if (user_choice == null | user_choice == "")
                    {
                        throw new Exception("Something went wrong!! Press any key to try again...");
                    }

                    int num_input = int.Parse(user_choice);
                    if (num_input < 1 | num_input > 2)
                    {
                        throw new FormatException();
                    }
                    switch (num_input)
                    {
                        case 1:
                            valid_choice = true;
                            Console.Clear();
                            Console.WriteLine("Please enter the temperature in Fahrenheit");
                            fahrenheit = decimal.Parse(Console.ReadLine());
                            celsius = MethodLibrary.Fahrenheit_to_Celsius(fahrenheit);
                            Console.WriteLine($"Name: \t{name}");
                            Console.WriteLine($"Email: \t{email}");
                            Console.WriteLine($"Experience Level: {xp_level}");
                            Console.WriteLine($"Country: {country}");
                            Console.WriteLine($"{fahrenheit} degrees Fahrenheit is {celsius} degrees Celsius");
                            if (celsius <= 0) 
                            { 
                                Console.WriteLine("\n\t\tBRRRR..... It's cold!! \n\nGOODBYE"); 
                            }
                            else 
                            { 
                                Console.WriteLine("\n\t\tAt least it is not snowing!!\n\nGOODBYE"); 
                            }
                            break;
                        case 2:
                            valid_choice = true;
                            Console.Clear();
                            Console.WriteLine("Please enter the temperature in Celsius");
                            celsius = decimal.Parse(Console.ReadLine());
                            fahrenheit = MethodLibrary.Celsius_to_Fahrenheit(celsius);
                            Console.WriteLine($"Name: \t{name}");
                            Console.WriteLine($"Email: \t{email}");
                            Console.WriteLine($"Experience Level: {xp_level}");
                            Console.WriteLine($"Country: {country}");
                            Console.WriteLine($"{celsius} degrees Celsius is {fahrenheit} degrees Fahrenheit");
                            if (fahrenheit <= 32)
                            {
                                Console.WriteLine("\n\t\tBRRRR..... It's cold!! \n\nGOODBYE");
                            }
                            else
                            {
                                Console.WriteLine("\n\t\tAt least it is not snowing!!\n\nGOODBYE");
                            }
                            break;
                    }   
                }
                catch (FormatException fEx)
                {
                    Console.Clear();
                    Console.WriteLine($"{fEx.Message}: \n{user_choice} is not a valid selection. \nPlease enter a selection of 1 OR 2. \nPress any key to try again..");
                    Console.ReadKey(false);
                }
                catch (Exception eX)
                {
                    Console.Clear();
                    Console.WriteLine(eX.Message);
                    Console.ReadKey(false);
                }   
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(false);
            Console.Clear();
        }
    }
}
