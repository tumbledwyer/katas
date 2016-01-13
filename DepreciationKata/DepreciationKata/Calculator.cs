using System;

namespace DepreciationKata
{
    public class Calculator
    {
        public decimal GetMonthlyDepreciation(Asset asset)
        {
            return (asset.Cost - asset.Residual)/asset.Life/12;
        }

        public int MonthsTillYearEnd(DateTime yearEnd, DateTime initialDate)
        {
            return yearEnd.Month - initialDate.Month;
        }

        public decimal Loss(int months, decimal monthlyDepreciation)
        {
            return months*monthlyDepreciation;
        }
    }
}