Feature: Bill Calculator

Scenario Outline: Bill Calculation for normal order
	Given the customer orders starters <countOfStarters>  Mains <countOfMains> Drinks <countOfDrinks>
	When the bill calculated for starters <countOfStarters> mains <countOfMains> drinks <countOfDrinks> for <HappyHour> in <CalculationMode>
	Then Verify the bill is correct <ExpectedBill>
	Examples: 
	| countOfStarters | countOfMains | countOfDrinks | ExpectedBill | HappyHour | CalculationMode |
	| 4               | 4            | 4             | 59.4         | false     | Creation        |

	Scenario Outline: Bill Calculation with Happy Hours
	Given the customer orders starters <countOfStarters>  Mains <countOfMains> Drinks <countOfDrinks>
	When the bill calculated for starters <countOfStarters> mains <countOfMains> drinks <countOfDrinks> for <HappyHour> in <CalculationMode>
	Then Verify the bill is correct <ExpectedBill>
	When the bill calculated for starters <AddedcountOfStarters> mains <AddedcountOfMains> drinks <AddedcountOfDrinks> for <NewHappyHour> in <NewCalculationMode>
	Then Verify the bill is correct <ExpectedBillafterupdation>

	Examples: 
	| countOfStarters | countOfMains | countOfDrinks | HappyHour | CalculationMode | ExpectedBill | AddedcountOfStarters | AddedcountOfMains | AddedcountOfDrinks | NewHappyHour | NewCalculationMode |ExpectedBillafterupdation |
	| 1               | 2            | 2             | true      | Creation        | 23.65        | 0                    | 2                 | 2                  | false        | Updation           | 44.55                    |

	Scenario Outline: Bill Calculation after cancellation of the orders
	Given the customer orders starters <countOfStarters>  Mains <countOfMains> Drinks <countOfDrinks>
	When the bill calculated for starters <countOfStarters> mains <countOfMains> drinks <countOfDrinks> for <HappyHour> in <CalculationMode>
	Then Verify the bill is correct <ExpectedBill>
	When the bill calculated for starters <RemovedcountOfStarters> mains <RemovedcountOfMains> drinks <RemovedcountOfDrinks> for <NewHappyHour> in <NewCalculationMode>
	Then Verify the bill is correct <ExpectedBillafterupdation>

	Examples: 
	| countOfStarters | countOfMains | countOfDrinks | HappyHour | CalculationMode | ExpectedBill | RemovedcountOfStarters | RemovedcountOfMains | RemovedcountOfDrinks | NewHappyHour | NewCalculationMode |ExpectedBillafterupdation |
	| 4               | 4            | 4             | false     | Creation        | 59.4         | 1                      | 1                   | 1                    | false        | Cancellation       | 44.55                    |