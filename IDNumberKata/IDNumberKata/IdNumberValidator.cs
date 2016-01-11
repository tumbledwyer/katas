namespace IDNumberKata
{
    public class IdNumberValidator
    {
        public IdParts ExtractIDParts(string idNumber)
        {
            return new IdParts
            {
                DOB = GetDatePart(idNumber),
                Gender = GetGender(idNumber),
                Citizenship = GetCitizenship(idNumber)
            };
        }

        private static string GetCitizenship(string idNumber)
        {
            var citizenDigit = int.Parse(idNumber[10].ToString());
            var citizen = "";
            if (citizenDigit == 0)
                citizen = "SA";
            else if (citizenDigit == 1)
                citizen = "Other";
            return citizen;
        }

        private static string GetGender(string idNumber)
        {
            var genderDigit = int.Parse(idNumber[6].ToString());
            return genderDigit < 5 ? "Female" : "Male";
        }

        private static string GetDatePart(string idNumber)
        {
            var yearPart = idNumber.Substring(0, 2);
            var century = int.Parse(yearPart) <= 20 ? "20" : "19";
            var monthPart = idNumber.Substring(2, 2);
            var dayPart = idNumber.Substring(4, 2);
            return $"{dayPart}-{monthPart}-{century}{yearPart}";
        }
    }

    public class IdParts
    {
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Citizenship { get; set; }
    }
}