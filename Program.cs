using System;

namespace DiceRollingSimulator
{
    // Prompts the user for the number of rolls, users the DiceRoller class to get the results, and then prints the histogram 
    class DiceRollSimulator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");
            int rolls = Convert.ToInt32(Console.ReadLine());

            DiceRoller roller = new DiceRoller();
            int[] results = roller.RollDice(rolls);

            Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {rolls}.");

            for (int i = 2; i <= 12; i++)
            {
                Console.Write($"{i}: ");
                int stars = (int)Math.Round(results[i - 2] / (double)rolls * 100);
                Console.WriteLine(new string('*', stars));
            }

            Console.WriteLine("Thank you for using the dice throwing simulator.");
            Console.WriteLine("Goodbye!");
        }
    }

    // This calss has a RollDice method tha tperforms the dice rolls and counts the frequency of each sum
    class DiceRoller
    {
        private static Random random = new Random();

        public int[] RollDice(int numberOfRolls)
        {
            int[] sums = new int[11]; // Array to store sums from 2 to 12

            for (int i = 0; i < numberOfRolls; i++)
            {
                int rollOne = random.Next(1, 7);
                int rollTwo = random.Next(1, 7);
                int sum = rollOne + rollTwo;

                sums[sum - 2]++;
            }

            return sums;
        }
    }
}
