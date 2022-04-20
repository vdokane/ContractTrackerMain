using NUnit.Framework;
using System;

namespace ContractTracker.Common.Test
{
    internal class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenJanuraryDateWillItGiveCorrectFiscalYearStartDate()
        {
            var testDate = new DateTime(2022, 1, 8);
            var calculcatedStartDate = DateCalculator.GetFiscalYearStartDate(testDate);
            var expectedStartDate = new DateTime(2021, 7, 1);
            var valueToAssert = (expectedStartDate.Date == calculcatedStartDate.Date);
            if (valueToAssert)
                Assert.Pass($"{calculcatedStartDate.Date} does have a fiscal year start date of {expectedStartDate.Date}");
            else
                Assert.Fail();
        }
        [Test]
        public void GivenJulyDateWillItGiveCorrectFiscalYearStartDate()
        {
            var testDate = new DateTime(2022, 7, 8);
            var calculcatedStartDate = DateCalculator.GetFiscalYearStartDate(testDate);
            var expectedStartDate = new DateTime(2022, 7, 1);
            var valueToAssert = (expectedStartDate.Date == calculcatedStartDate.Date);
            if (valueToAssert)
                Assert.Pass($"{calculcatedStartDate.Date} does have a fiscal year start date of {expectedStartDate.Date}");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenAugustDateWillItGiveCorrectFiscalYearStartDate()
        {
            var testDate = new DateTime(2022, 8, 20);
            var calculcatedStartDate = DateCalculator.GetFiscalYearStartDate(testDate);
            var expectedStartDate = new DateTime(2022, 7, 1);
            var valueToAssert = (expectedStartDate.Date == calculcatedStartDate.Date);
            if (valueToAssert)
                Assert.Pass($"{calculcatedStartDate.Date} does have a fiscal year start date of {expectedStartDate.Date}");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenJuneDateWillItGiveCorrectFiscalYearStartDate()
        {
            var testDate = new DateTime(2022, 6, 20);
            var calculcatedStartDate = DateCalculator.GetFiscalYearStartDate(testDate);
            var expectedStartDate = new DateTime(2021, 7, 1);
            var valueToAssert = (expectedStartDate.Date == calculcatedStartDate.Date);
            if (valueToAssert)
                Assert.Pass($"{calculcatedStartDate.Date} does have a fiscal year start date of {expectedStartDate.Date}");
            else
                Assert.Fail();
        }
        
        [Test]
        public void GivenValidDateIsInCurrentFiscalYear()
        {
            var now = DateTime.Now;
            var testDate = new DateTime(now.Year, 1, 8);
            var inCurrentFiscalYear = DateCalculator.InCurrentFiscalYear(testDate);
            if (inCurrentFiscalYear)
                Assert.Pass($"{testDate.Date} is in the current fiscal year.");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenInValidDateIsInCurrentFiscalYear()
        {
            var testDate = new DateTime(1999, 1, 8);
            var inCurrentFiscalYear = DateCalculator.InCurrentFiscalYear(testDate);
            if (!inCurrentFiscalYear)
                Assert.Pass($"{testDate.Date} is NOT in the current fiscal year.");
            else
                Assert.Fail();
        }

        [Test]
        public void UsingTheCurrentDateWillFiscalYearEndDateBeCorrect()
        {
            var now = DateTime.Now;
            var testDate = new DateTime(now.Year, 1, 8);

            var calculatedEndDate = DateCalculator.GetFiscalYearEndDate(testDate);
            var expectedEndDate = new DateTime(now.Year, 6, 30);

            var valueToAssert = (expectedEndDate.Date == calculatedEndDate.Value.Date);
            if (valueToAssert)
                Assert.Pass($"{calculatedEndDate.Value.Date} does have a fiscal year end date of {expectedEndDate.Date}");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenTheFirstDateOfTheFiscalYearWillFiscalYearEndDateBeCorrect()
        {
            var testDate = new DateTime(2021, 7, 1);

            var calculatedEndDate = DateCalculator.GetFiscalYearEndDate(testDate);
            var expectedEndDate = new DateTime(2022, 6, 30);

            var valueToAssert = (expectedEndDate.Date == calculatedEndDate.Value.Date);
            if (valueToAssert)
                Assert.Pass($"{calculatedEndDate.Value.Date.ToShortDateString()} does have a fiscal year end date of {expectedEndDate.Date.ToShortDateString()}");
            else
                Assert.Fail();
        }

        [Test]
        public void ProvidedTheDisplayDateIsCorrectWillAValidDateInTheFiscalYearPass()
        {
            var testDate = new DateTime(2022,1,8);
            const string displayDateExpected = "FY 2021-2022";

            var displayDateCalculated = DateCalculator.GetFiscalYearDisplay(testDate);

            if (displayDateExpected == displayDateCalculated)
                Assert.Pass($"{displayDateCalculated} is correct display");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenAPastDateWillTheDisplayDateIsCorrectWillAValidDateInTheFiscalYearPass()
        {
            var testDate = new DateTime(2021, 10, 8);
            const string displayDateExpected = "FY 2021-2022";

            var displayDateCalculated = DateCalculator.GetFiscalYearDisplay(testDate);

            if (displayDateExpected == displayDateCalculated)
                Assert.Pass($"{displayDateCalculated} is correct display");
            else
                Assert.Fail();
        }

        [Test]
        public void GivenAFutureDateWillTheDisplayDateIsCorrectWillAValidDateInTheFiscalYearPass()
        {
            var testDate = new DateTime(2022, 7, 13);
            const string displayDateExpected = "FY 2022-2023";

            var displayDateCalculated = DateCalculator.GetFiscalYearDisplay(testDate);

            if (displayDateExpected == displayDateCalculated)
                Assert.Pass($"{displayDateCalculated} is correct display");
            else
                Assert.Fail();
        }

        [Test]
        public void CanAFutureFiscalYearBeDetermined()
        {
            var testDate = new DateTime(2023, 7, 1);
            var isFuture = DateCalculator.InFutureFiscalYear(testDate);
            Assert.IsTrue( isFuture);
        }

        [Test]
        public void WtfDate()
        {
            var testDate = new DateTime(2023, 1, 20);
            var isFuture = DateCalculator.InFutureFiscalYear(testDate);
            Assert.IsTrue(isFuture);
        }
    }
}