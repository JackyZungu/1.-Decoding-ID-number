using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Decoding_ID_number
{
    public class Program
    {
        public static void Main(string[] arg)
        {
            Console.WriteLine("Enter a South African ID number: ");

            string idNum = Console.ReadLine();

            bool validSAIdNum = IsValIdNum(idNum);
            if (validSAIdNum)
            {
                string dateOfBirth = idNum.Substring(0, 6);
                int genderDigit = int.Parse(idNum.Substring(6, 1));
                char citizenStatus = idNum[10];

                // Determine gender based on the first digit of SSSS
                string gender = (genderDigit < 5) ? "Female" : "Male";

                // Determine citizenship status
                string citizenship = (citizenStatus == '0') ? "SA Citizen" : "Permanent Resident";

                Console.WriteLine("Date of Birth: " + dateOfBirth);
                Console.WriteLine("Gender: " + gender);
                Console.WriteLine("Citizenship: " + citizenship);
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("The ID number is not valid.");
            }
        }
        public static bool IsValIdNum(string idNum)

        {// Check if the ID number is the correct length.
            if (idNum.Length == 13)
            {
                return true;
            }

            // Double every second digit, starting from the rightmost digit.
            int sumOfDoubledDigits = 0;
            for (int i = idNum.Length - 2; i >= 0; i -= 2)
            {
                int doubledDigit = idNum[i] * 2;
                if (doubledDigit > 9)
                {
                    doubledDigit -= 9;
                }

                sumOfDoubledDigits += doubledDigit;
            }

            // Add the remaining (odd) digits of the ID number to the sum.
            int sumOfAllDigits = sumOfDoubledDigits;
            for (int i = idNum.Length - 1; i >= 0; i -= 2)
            {
                sumOfAllDigits += idNum[i] - '0';
            }

            // If the sum is divisible by 10, the ID number is valid.
            return sumOfAllDigits % 10 == 0;
        }
    } 
}










