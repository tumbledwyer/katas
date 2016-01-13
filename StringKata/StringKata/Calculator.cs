using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            CheckForNegatives(GetNumbersFromInput(input));
            return GetNumbersFromInput(input).Select(int.Parse).Where(s => s <= 1000).Sum();
        }

        private static void CheckForNegatives(IEnumerable<string> numbersFromInput)
        {
            if (numbersFromInput.Any(s => s.Contains('-')))
                throw new Exception(
                    $"negatives not allowed: {numbersFromInput.Where(s => s.Contains('-')).Aggregate("", (current, negative) => current + negative)}");
        }

        private IEnumerable<string> GetNumbersFromInput(string input)
        {
            return GetComputableSubstring(input).Split(GetDelimiters(input));
        }

        private char[] GetDelimiters(string input)
        {
            return InputHasCustomDelimiter(input) ? new[] { input[2]} : new[] {',', '\n'};
        }

        private string GetComputableSubstring(string input)
        {
            return InputHasCustomDelimiter(input) ? input.Substring(4) : input;
        }

        private bool InputHasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }
    }
}
