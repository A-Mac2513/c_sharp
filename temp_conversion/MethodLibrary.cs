using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MethodLibrary
    {
        static private StreamWriter writer;
        static private StreamReader reader;
        static private string _path = @"../../../(FolderName)"; //*** Name this Folder ***
        static private string _file = "(File Name)";   //*** Name This File ***
        static private string _filePath = $"{_path}/{_file}.txt";

        public static string GetRidOfPunctuation(string input)
        {
            string output = "";
            string[] words;
            char[] letters = null;
            char[] delim = { '/', '*', '(', ')', '%', '$', '#', '@', '!', ':',
                ';', '?', '<', '>', '_', '"', '=', '+', '[', ']', '{', '}' };
            string newString = "";

            // If input in empty return the string as empty
            if (String.IsNullOrEmpty(input))
            {
                return output = "";
            }

            // trims the the front and back of the input string
            input = input.Trim();

            // takes each word and assigns the individual word to a string array
            words = input.Split(null);

            for (int z = 0; z < words.Length; z++)
            {
                int y = 0;
                words[z] = words[z].Trim().ToUpper();

                if (words[z] != "")
                {
                    letters = words[z].ToCharArray();

                    foreach (char ch in letters)
                    {
                        if (delim.Contains(ch))
                        {
                            letters[y] = '-';
                        }
                        y++;
                    }

                    for (int x = 0; x < (letters.Length - 1); x++)
                    {
                        if (letters[x] == ' ')
                        {
                            letters[x] = letters[x + 1];
                            letters[x + 1] = ' ';
                        }
                    }

                    // This is repeated in case there was 2 deliminators in a row removed
                    for (int x = 0; x < (letters.Length - 1); x++)
                    {
                        if (letters[x] == ' ')
                        {
                            letters[x] = letters[x + 1];
                            letters[x + 1] = ' ';
                        }
                    }

                    words[z] = string.Join("", letters);
                    words[z] = words[z].Trim();
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    newString += $"{words[i]} ";
                }
            }

            output = newString.Trim();
            return output;
        }

        public static string TitleCaseAllWords(params string[] input)
        {
            int y = 0;
            string newString = "";
            foreach (string str in input)
            {
                if (str.Length > 1)
                {
                    input[y] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
                }
                newString += input[y];
                y++;
            }
            return newString;
        }

        public static Boolean ValidateEmail (string email)
        {
            Regex checkEmail = new Regex(@"^([A-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,5})$");
            if (checkEmail.IsMatch(email))
                return true;

            return false;
        }

        public static Boolean ValidatePhoneNumber(string phoneNum)
        {
            Regex checkPhoneNumOne = new Regex(@"^[0-9]{3}\s[0-9]{3}\s[0-9]{4}$");
            Regex checkPhoneNumTwo = new Regex(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{4}$");

            if (checkPhoneNumOne.IsMatch(phoneNum) || checkPhoneNumTwo.IsMatch(phoneNum))
                return true;

            return false;
        }

        public static Boolean ValidatePostalCode (string postalCode)
        {
            Regex ukPostalCode = new Regex(@"^[A-Z]{1}[A-Z]?[0-9]{1}([A-Z]|[0-9])?\s?[0-9]{1}[A-Z]{2}$", RegexOptions.IgnoreCase);
            Regex canadianPostalCode = new Regex(@"^[A-Z]{1}[0-9]{1}[A-Z]{1}[-\s][0-9]{1}[A-Z]{1}[0-9]{1}$", RegexOptions.IgnoreCase);
            Regex usZipCode = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");

            if (ukPostalCode.IsMatch(postalCode) || canadianPostalCode.IsMatch(postalCode) || usZipCode.IsMatch(postalCode))
                return true;

            return false;
        }

        public static Boolean ValidatePassWord (string password)
        {
            return false;
        }

        public static void PrintArray (string [] Array)
        {
            string print = "";
            foreach (string str in Array)
            {
                if (str.Length == 4)
                {
                    print += $"{str} \n";
                }
                else
                {
                    continue;
                }
            }
        }

        public static void SearchArray()
        {

        }

        public static Boolean IsStringArrayFull (string[] Array)
        {
            if (!Array.Contains("") && !Array.Contains(null))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static Boolean IsIntArrayFull(int[] Array)
        {
            if (!Array.Equals(-1) && !Array.Equals(null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string UseRegexToManipulate(string phrase)
        {
            return Regex.Replace(phrase, @"\p{P}", String.Empty);
        }

        // Looking for a match in FILE IO
        // Check to see if name already exists
        public static bool NameExists(string name)
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("You Have not created an Inventory Record yet, please choose to ADD NEW item.");

            using (reader = new StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string readLine = reader.ReadLine();
                    string[] record = readLine.Split('|');

                    if (record[0].Equals(name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Random Number Generator
        public static int GetNewIdNumber()
        {
            Random idNumber = new Random();
            int id;
            id = idNumber.Next(0, 999);
            while (CheckIdNumberExists(id))
            {
                id = idNumber.Next(0, 999);
            }
            return id;
        }

        public static Boolean CheckIdNumberExists(int id)
        {
            List<int> idNumbersUsed = new List<int>();
            try
            {
                using (reader = new StreamReader(_filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string userItem = reader.ReadLine();
                        string[] splitItem = userItem.Split('|');
                        idNumbersUsed.Add(int.Parse(splitItem[0]));
                    }
                }
            }
            catch (FileLoadException fLEx)
            {
                throw new FileLoadException($"{fLEx.Message}.\n A problem occured while loading file! Please Try Again!");
            }
            catch (FileNotFoundException fNfEx)
            {
                throw new FileNotFoundException($"{fNfEx.Message}.\n Your File could not be found! Please Try Again!");
            }
            catch (IOException IOeX)
            {
                throw new IOException($"{IOeX.Message}.\n An ERROR occured! Please Try Again!");
            }
            catch (Exception eX)
            {
                throw new Exception($"{eX.Message}. Please Try Again.");
            }

            foreach (int number in idNumbersUsed)
            {
                if (number.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetAge(DateTime DOB)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DOB.Year;

            if (today.Month < DOB.Month || (today.Month == DOB.Month && today.Day < DOB.Day))
                age--;

            return age;
        }

        public static decimal Fahrenheit_to_Celsius(decimal temp)
        {
            return (temp - 32) * 5 / 9;
        }

        public static decimal Celsius_to_Fahrenheit(decimal temp)
        {
            return (temp * 9 / 5) + 32;
        }
    }
}
