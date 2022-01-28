using FluentAssertions;
using SpecflowArgus.CommonFunctions;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecflowArgus.Steps
{
    [Binding]
    public class BillCalculatorSteps
    {
        BillCalculatorCommonFunction objBillCalculator = new BillCalculatorCommonFunction();
        double actualBill = 0.00;

        [Given(@"the customer orders starters (.*)  Mains (.*) Drinks (.*)")]
        public void GivenTheCustomerOrdersStartersMainsDrinks(int countOfStarters, int countOfMains, int countOfDrinks)
        {
            Console.WriteLine("Customer ordered the starters:" + countOfStarters + "Mains :" + countOfMains + "Drinks:" + countOfDrinks);
        }

        [When(@"the bill calculated for starters (.*) mains (.*) drinks (.*) for (.*) in (.*)")]
        public void WhenTheBillCalculatedForStartersMainsDrinksForFalseInCreation(int countOfStarters, int countOfMains, int countOfDrinks, bool isHappyHours, string calculationMode)
        {

            if (calculationMode.Equals( "Creation"))
            {
                actualBill = objBillCalculator.BillCalculation(countOfStarters, countOfMains, countOfDrinks,isHappyHours);
            }
            else if (calculationMode.Equals("Updation"))
            {
                double previousBill = actualBill;
                actualBill = previousBill + objBillCalculator.BillCalculation(countOfStarters, countOfMains, countOfDrinks, isHappyHours);
            }
            else if (calculationMode.Equals("Cancellation"))
            {
                double previousBill = actualBill;
                actualBill = previousBill - objBillCalculator.BillCalculation(countOfStarters, countOfMains, countOfDrinks, isHappyHours);
            }
            Console.WriteLine("Actual Bill calculated :" + actualBill);
        }


        [Then(@"Verify the bill is correct (.*)")]
        public void ThenVerifyTheBillIsCorrect(double expectedBill)
        {
            Assert.AreEqual(expectedBill, actualBill);
        }
    }
}
