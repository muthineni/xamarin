using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharterUsers.Utilities
{
    public class StringValidator
    {
        static int MAX_CHAR = 256;

        public StringValidator()
        {
        }

        public static bool isValidPassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Password should not be empty.";
                return false;
            }

            var hasAlphaNumeric = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$");
            var hasMinMaxChars = new Regex(@"^.{5,12}$");

            if (!hasAlphaNumeric.IsMatch(input))
            {
                ErrorMessage = "Password should contain only letters and digits .";
                return false;
            }
            else if (!hasMinMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 5 or greater than 12 characters.";
                return false;
            }
            else if (checkRepeatedSequence(input))
            {
                ErrorMessage = "Password should not contain repeated sequence.";
                return false;
            }
            else
            {
                return true;
            }
        }

        //String Empty check
        public static bool isStringEmpty(string text)
        {
            var input = text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // string  palindrome check
        private static bool isPalindrome(String str,
                                        int l, int h)
        {
            // l and h are leftmost and rightmost corners of str
            // Keep comparing characters while they are same
            while (h > l)
                if (str[l++] != str[h--])
                    return false;

            return true;
        }

        //program to check if any repeated subsequence exists in the string
        private static bool checkRepeatedSequence(String str)
        {
            // Find length of input string
            int n = str.Length;

            // Create an array to store all characters
            // and their frequencies in str[]
            int[] freq = new int[MAX_CHAR];

            // Traverse the input string and store frequencies
            // of all characters in freq[] array.
            for (int i = 0; i < n; i++)
            {
                freq[str[i]]++;

                // If the character count is more than 2
                // we found a repetition
                if (freq[str[i]] > 2)
                    return true;
            }

            // In-place remove non-repeating characters
            // from the string
            int k = 0;
            for (int i = 0; i < n; i++)
                if (freq[str[i]] > 1)
                    str.Replace(str[k++],
                                str[i]);
            str.Replace(str[k], '\0');
            // check if the resultant string is palindrome
            if (isPalindrome(str, 0, k - 1))
            {

                // special case - if length is odd
                // return true if the middle character is
                // same as previous one
                if ((k & 1) == 1)
                {

                    // It is checked so that
                    // StringIndexOutOfBounds can be avoided
                    if (k / 2 >= 1)
                        return (str[k / 2] ==
                                str[k / 2 - 1]);
                }

                // return false if string is a palindrome
                return false;
            }

            // return true if string is not a palindrome
            return true;
        }
    }
}