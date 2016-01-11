using System;

namespace AgeCalculator
{
    public class AgeCalculator
    {
        public int GetAge(DateTime birthDate, DateTime chosenDate)
        {
            CheckForValidAgeRange(birthDate, chosenDate);

            if (IsALeapling(birthDate) && EndOfFeb(chosenDate) && NotALeapYear(chosenDate))
                return UnadjustedAge(birthDate, chosenDate);
            if (EarlierMonthInTheYear(birthDate, chosenDate) || EarlierDayInTheSameMonth(birthDate, chosenDate))
                return AdjustAgeBy1(birthDate, chosenDate);
            return UnadjustedAge(birthDate, chosenDate);
        }

        private static bool EarlierMonthInTheYear(DateTime birthDate, DateTime chosenDate)
        {
            return chosenDate.Month < birthDate.Month;
        }

        private static bool EarlierDayInTheSameMonth(DateTime birthDate, DateTime chosenDate)
        {
            return chosenDate.Month == birthDate.Month && chosenDate.Day < birthDate.Day;
        }

        private bool EndOfFeb(DateTime date)
        {
            return date.Month == 2 && date.Day == 28;
        }

        private static bool IsALeapling(DateTime birthDate)
        {
            return birthDate.Month == 2 && birthDate.Day == 29;
        }

        private static int UnadjustedAge(DateTime birthDate, DateTime chosenDate)
        {
            return chosenDate.Year - birthDate.Year;
        }

        private bool NotALeapYear(DateTime chosenDate)
        {
            return !DateTime.IsLeapYear(chosenDate.Year);
        }

        private static void CheckForValidAgeRange(DateTime birthDate, DateTime chosenDate)
        {
            if (birthDate > chosenDate)
                throw new Exception("Age out of range");
        }

        private static int AdjustAgeBy1(DateTime birthDate, DateTime chosenDate)
        {
            return chosenDate.Year - birthDate.Year - 1;
        }
    }
}