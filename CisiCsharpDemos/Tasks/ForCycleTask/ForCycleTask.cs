using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CisiCsharpDemos.Tasks
{
    class ForCycleTaskSet : AbstractTaskSet, ITaskSet
    {
        public override void Open()
        {
            PrintSection("For cycle task set");
        }

        public override void Close()
        {

        }

        public override void Run()
        {
            // Vypište vedle sebe malou násobilku 8mi
            SmallMultiplierAdjacent(8);

            // Vypište pod sebe malou násobilku 8mi s tím, že budeme vypisovat i samotný postup výpočtu
            SmallMultiplierUnderWithProcedure(8);

            // Vypište čísla od 20 do -20 sestupně
            NumberLineFromToDescending(20, -20);

            // Odečtěte od proměnné cislo 5krát číslo 8
            DeductNumberFromNumberMultiple(50, 8, 5);

            // Vypište vedle sebe tolikrát znak %, kolikrát zadá uživatel
            WritePercentageCharBasedOnUserInput();

            // Vypište pod sebe tolik náhodných čísel, kolik zadá uživatel
            WriteRandomNumbersBasedOnUserInput();

            // Vypište všechna čísla od -200 do 200 dělitelné číslem, které zadá uživatel 
            NumbersDivisibleByDivisorBasedOnUserInput(-200, 200);

            // Uživatel zadá větší a poté menší číslo.
            // Cyklus vypíše všechna čísla přesně mezi těmito čísly, a to vedle sebe a sestupně.
            NumbersInIntervalDefinedByUserInput();

            // Vypište všechny čísla z rozsahu, který zadá uživatel (od, do), které jsou dělitelné číslem 17
            NumbersInIntervalDividableByDivisorDefinedByUserInput(17);

            // Vypište vedle sebe 20 náhodných čísel od -15 do 15 a pod ně napište, kolik z těchto čísel je sudých a kolik je lichých. 
            // Pozn. 0 není sudá ani lichá
            RandomNumbersInIntervalWhichAreOddAndEven(20, -15, 15);

            // Vypočítejte faktoriál čísla x zadaného uživatelem
            // Pozn.pokud x = 5, výsledek je 5 * 4 * 3 * 2 * 1 = 120
            FactorialOfNumberDefinedByUser();

            // Počítač pomocí generátoru náhodných čísel generuje 100 čísel od 0 do 9.
            // Žádoucí jsou však pouze cifry z binární soustavy(0 a 1).
            // Výstup: Na consoli se po ukončení cyklu pouze vypíše, kolik čísel nevyhovovalo zadání, tedy kolik z losovaných čísel bylo v rozmezí 2.. 9.
            RandomNumbersInIntervalWhichAreZeroOrOne(100, 0, 9);
        }

        private void RandomNumbersInIntervalWhichAreZeroOrOne(int limit, int from, int to)
        {
            PrintSection("Random numbers in interval which are zero or one");

            Random randomGenerator = new Random();

            int validNumbers = 0;

            for(int i = 0; i < limit; i++)
            {
                int randomNumber = randomGenerator.Next(from, to);

                if(randomNumber == 0 || randomNumber == 1)
                {
                    validNumbers++;
                }
            }

            PrintTextLine(string.Format("From {0} random numbers were {1} zero or one", limit, validNumbers));

            PrintEndSection();
        }

        private void FactorialOfNumberDefinedByUser()
        {
            PrintSection("Factorial of number defined by user");

            PrintText("Write number which is going to factorized: ");

            string userInput = Console.ReadLine();
            int number = 0;

            bool isUserInputValid = int.TryParse(userInput, out number);

            if(isUserInputValid)
            {
                int result = number;

                for (int i = 1; i < number; i++)
                {
                    result = result * i;
                }

                PrintTextLine(string.Format("Factorial of number {0} is {1}", number, result));
            }
            else
            {
                PrintTextLine("Number is not valid integer!");
            }

            PrintEndSection();
        }

        private void RandomNumbersInIntervalWhichAreOddAndEven(int limit, int from, int to)
        {
            PrintSection("Random numbers in interval which are odd and even");

            Random randomGenerator = new Random();
            int oddNumbersCount = 0;
            int evenNumbersCount = 0;

            for (int i = 0; i < limit; i++)
            {
                int randomNumber = randomGenerator.Next(from, to);

                bool isOdd = randomNumber % 2 != 0;
                bool isEven = randomNumber % 2 == 0;

                if (randomNumber == 0)
                {
                    // Dle zadani "0 není sudá ani lichá" coz neni pravda, nula je suda i licha zaroven
                    // Kod nize ale pracuje dle zadani, ac nespravneho
                    // BTW: Nase funcke pro kontrolu rekne ze nula je suda, coz je castecne spravne viz. wiki "Even-odd alternation"
                    isEven = false;
                    isOdd = false;
                }

                if (isOdd)
                {
                    oddNumbersCount++;
                }

                if(isEven)
                {
                    evenNumbersCount++;
                }

                PrintText(string.Format("{0} ", randomNumber));
            }

            PrintTextLine(string.Empty);

            PrintTextLine(string.Format("Odd numbers count: {0}", oddNumbersCount));
            PrintTextLine(string.Format("Odd numbers count: {0}", evenNumbersCount));

            PrintEndSection();
        }

        // Tato metoda je velmi podobna jako NumbersInIntervalDefinedByUserInput ale v ramci citelnosti je zkopirovana a upravena
        private void NumbersInIntervalDividableByDivisorDefinedByUserInput(int divisor)
        {
            PrintSection("Numbers in interval dividable by divisor defined by user input");

            PrintText("Write starting number of interval: ");

            string startingNumberString = Console.ReadLine();
            int startingNumber = 0;

            PrintText("Write ending number of interval: ");

            string endingNumberString = Console.ReadLine();
            int endingNumber = 0;

            bool isStartingNumberValid = int.TryParse(startingNumberString, out startingNumber);
            bool isEndingNumberValid = int.TryParse(endingNumberString, out endingNumber);

            if (isEndingNumberValid && isEndingNumberValid)
            {
                if (!(endingNumber < startingNumber))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    
                    for (int i = startingNumber; i <= endingNumber; i++)
                    {
                        float number = i / (float)divisor;

                        bool isFractional = (Math.Floor(number) != number);

                        if (!isFractional)
                        {
                            stringBuilder.AppendFormat("{0} ", i);
                        }
                    }

                    string result = stringBuilder.ToString();

                    PrintTextLine(result);
                }
                else
                {
                    PrintTextLine("Ending number is smaller than starting!");
                }
            }
            else
            {
                PrintTextLine("Starting or ending number is not valid integer!");
            }

            PrintEndSection();
        }

        private void NumbersInIntervalDefinedByUserInput()
        {
            PrintSection("Numbers in interval defined by user input");

            PrintText("Write starting number of interval: ");

            string startingNumberString = Console.ReadLine();
            int startingNumber = 0;

            PrintText("Write ending number of interval: ");

            string endingNumberString = Console.ReadLine();
            int endingNumber = 0;

            bool isStartingNumberValid = int.TryParse(startingNumberString, out startingNumber);
            bool isEndingNumberValid = int.TryParse(endingNumberString, out endingNumber);

            if(isEndingNumberValid && isEndingNumberValid)
            {
                if(!(endingNumber < startingNumber))
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    // Cyklus pracuje sestupne
                    for (int i = endingNumber; i >= startingNumber; i--)
                    {
                        stringBuilder.AppendFormat("{0} ", i);
                    }

                    string result = stringBuilder.ToString();

                    PrintTextLine(result);
                }
                else
                {
                    PrintTextLine("Ending number is smaller than starting!");
                }
            }
            else
            {
                PrintTextLine("Starting or ending number is not valid integer!");
            }

            PrintEndSection();
        }

        private void NumbersDivisibleByDivisorBasedOnUserInput(int from, int to)
        {
            PrintSection("Numbers divisible by divisor based on user input");

            PrintText("Write desired divisor for number from interval (-200, 200): ");

            string userInput = Console.ReadLine();
            int divisor = 0;

            bool isUserInputValid = int.TryParse(userInput, out divisor);

            if (isUserInputValid)
            {
                if (divisor == 0)
                {
                    PrintTextLine("You have zero as denominator which result is undefined!");
                }
                else
                {
                    Random randomGenerator = new Random();

                    for (int i = from; i < to; i++)
                    {
                        // Zaokrouhli na dve desetinne mista. Je mozne pouzit double nebo decimal jako prvni argument. Decimal vzdy pouzivat pri praci s penezi!
                        // Je nutne aby divisor byl pretypovan na float PRED delenim, jinak probehne celociselne deleni a vysledek bude bez desetinne casti
                        float result = (i / (float)divisor);

                        // Zapis {2:0.00} rika ze se maji zobrazit dve desetinna mista (pozor nezaokrouhluje!!)
                        PrintTextLine(string.Format("{0}/{1} = {2:0.00} ", i, divisor, result));
                    }
                }
            }
            else
            {
                PrintTextLine("You have entered invalid number!");
            }
        }

        private void WriteRandomNumbersBasedOnUserInput()
        {
            PrintSection("Write random numbers based on user input");

            PrintText("Write how many random numbers you like output: ");
            
            string userInput = Console.ReadLine();
            int numberOfRepeats = 0;

            bool isUserInputValid = int.TryParse(userInput, out numberOfRepeats);

            if (isUserInputValid)
            {
                if (numberOfRepeats <= 0)
                {
                    PrintTextLine("You have entered negative or zero number!");
                }
                else
                {
                    Random randomGenerator = new Random();

                    for (int i = 0; i < numberOfRepeats; i++)
                    {
                        // Nahodne cisla od 1 do 1000000
                        PrintText(string.Format("{0} ", randomGenerator.Next(1, 1000000)));
                    }
                }
            }
            else
            {
                PrintTextLine("You have entered invalid number!");
            }

            PrintEndSection();
        }

        private void WritePercentageCharBasedOnUserInput()
        {
            PrintSection("Write percentage char based on user input");

            PrintText("Write how many times you like to repeat the char %: ");

            string userInput = Console.ReadLine();
            int numberOfRepeats = 0;

            bool isUserInputValid = int.TryParse(userInput, out numberOfRepeats);

            if(isUserInputValid)
            {
                if(numberOfRepeats <= 0)
                {
                    PrintTextLine("You have entered negative or zero number!");
                }
                else
                {
                    for(int i = 0; i < numberOfRepeats; i++)
                    {
                        PrintText(string.Format("{0} ", "%"));
                    }
                }
            }
            else
            {
                PrintTextLine("You have entered invalid number!");
            }

            PrintEndSection();
        }

        private void DeductNumberFromNumberMultiple(int sourceNumber, int minusNumber, int repeats)
        {
            PrintSection("Deduct number from number multiple time");

            int result = sourceNumber;

            for(int i = 0; i < repeats; i++)
            {
                result -= minusNumber;
            }

            PrintTextLine(result.ToString());
        }

        private void NumberLineFromToDescending(int from, int to)
        {
            PrintSection("Number line from to");

            for (int i = from; i >= to; i--)
            {
                PrintText(string.Format("{0} ", i));
            }

            PrintTextLine(string.Empty);
        }

        private void SmallMultiplierAdjacent(int baseNumber)
        {
            PrintSection("Small multiplier adjacent");

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i <= 10; i++)
            {
                int result = baseNumber * i;

                stringBuilder.AppendFormat("{0}, ", result);
            }

            // Trim last ","
            string line = stringBuilder.ToString().TrimEnd(new char[] { ' ', ',' });

            PrintTextLine(line);
        }

        private void SmallMultiplierUnderWithProcedure(int baseNumber)
        {
            PrintSection("Small multiplier under");

            for (int i = 0; i <= 10; i++)
            {
                int result = baseNumber * i;

                PrintTextLine(string.Format("{0} * {1} = {2}", baseNumber, i, result));
            }
        }
    }
}
