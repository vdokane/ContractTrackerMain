using System.Text;

namespace ContractTracker.Common
{
    public class DateCalculator
    {
        /// <summary>
        /// If it is after July 1st, it is FY [current year] - [current year + 1] 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetFiscalYearDisplay(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            var fiscalYearStartDate = GetFiscalYearStartDate(date.Value);
            var fiscalYear = fiscalYearStartDate.Year;

            StringBuilder sb = new StringBuilder("FY ");
            sb.Append(fiscalYear).Append("-").Append(fiscalYear + 1);

            return sb.ToString();
        }

        public static int? GetFiscalYear(DateTime? date)
        {
            if (!date.HasValue)
                return null;
            return GetFiscalYearStartDate(date.Value).Year;
        }

        public static DateTime? GetFiscalYearEndDate(DateTime? date)
        {
            var fiscalYear = GetFiscalYear(date);

            if (!fiscalYear.HasValue)
                return null;

            return new DateTime((fiscalYear.Value + 1), 6, 30);
        }

        public static bool InCurrentFiscalYear(DateTime? date)
        {
            if (!date.HasValue)
                return false;

            var now = DateTime.Now;
            var currentFiscalYearStartDate = GetFiscalYearStartDate(now);
            var currentFiscalYearEndDate = GetFiscalYearEndDate(now);

            return date.Value.Date >= currentFiscalYearStartDate.Date && date.Value.Date <= currentFiscalYearEndDate.Value.Date;
        }

        /// <summary>
        /// A date is in a future fiscal year if the fiscal year start date of the given date is greater than the current date's FY end date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool InFutureFiscalYear(DateTime? date)
        {
            //get end of current FY using now
            //get start date of potential FY using effective date
            if (!date.HasValue)
                return false;

            var now = DateTime.Now;
            var currentFiscalYearEndDate = GetFiscalYearEndDate(now);
            var selectedFiscalYearStartDate = GetFiscalYearStartDate(date.Value);
            return selectedFiscalYearStartDate.Date > currentFiscalYearEndDate.Value.Date; 
        }

        public static DateTime GetFiscalYearStartDate(DateTime date)
        {
            int currentYear = date.Year;
            int previousYear = (date.Year - 1);
            int fiscalYear = 0;

            if (date.Month >= 7)
            {
                fiscalYear = currentYear;
            }
            else
            {
                fiscalYear = previousYear;
            }

            var fiscalYearStartDate = new DateTime(fiscalYear, 7, 1);
            return fiscalYearStartDate;
        }

    }
}