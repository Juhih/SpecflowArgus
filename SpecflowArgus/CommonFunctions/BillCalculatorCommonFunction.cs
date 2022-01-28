using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowArgus.CommonFunctions
{
    public class BillCalculatorCommonFunction
    {
        
        public double BillCalculation(int countOfStarters =0,int countOfMains=0, int countOfDrinks=0, bool isHappyHour = false)
        {
            double startersBill;
            double mainsBill;
            double DrinksBill;
 
             startersBill = CalculatePriceOfStarters(countOfStarters);
             mainsBill = CalculatePriceOfMains(countOfMains);
             DrinksBill = CalculatePriceOfDrinks(countOfDrinks, isHappyHour);

             double TotalBill = (startersBill + mainsBill + DrinksBill) * 1.1;
            TotalBill = (double)System.Math.Round(TotalBill, 2);
            return TotalBill;
        }

        public double CalculatePriceOfMains(int count)
        {
            double priceOfMains = count * 7.00;
            return priceOfMains;
        }

        public double CalculatePriceOfStarters(int count)
        {
            double priceOfStarters = count * 4.00;
            return priceOfStarters;
        }

        public double CalculatePriceOfDrinks(int count, bool isHappyHour)
        {
            double priceOfDrinks;
            if (isHappyHour)
            {
                 priceOfDrinks = (count * 2.50) * 0.7;
            }
            else
            {
                priceOfDrinks = count * 2.50;
            }
            return priceOfDrinks;
        }
    }
}
