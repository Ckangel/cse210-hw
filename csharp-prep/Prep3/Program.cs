using System;

class Program
{
    static void Main(string[] args)
    using System;
    {
        Console.WriteLine("Hello Prep3 World!");
    }
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain;

        do
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to the Guessing Game!");

            // Loop until the user guesses the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                // Read user input and convert it to an integer
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                // Check if the guess is higher, lower, or correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";

        } while (playAgain);

        Console.WriteLine("Thank you for playing!");
    }
}