namespace Fizzbuzz
{
    public class FizzBuzz
    {
        public string FizzBuzzer(int input)
        {
            if (DivisibleBy3(input) && DivisibleBy5(input))
                return "FizzBuzz";
            if (DivisibleBy3(input))
                return "Fizz";
            if (DivisibleBy5(input))
                return "Buzz"; 
            return input.ToString();
        }

        private static bool DivisibleBy5(int input)
        {
            return input % 5 == 0;
        }

        private static bool DivisibleBy3(int input)
        {
            return input % 3 == 0;
        }
    }
}