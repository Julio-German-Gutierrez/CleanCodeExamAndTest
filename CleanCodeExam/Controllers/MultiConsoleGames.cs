using CleanCodeExam.Factories;
using CleanCodeExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExam.Controllers
{
    public class MultiConsoleGames
    {
        static readonly char EXIT = '4';

        public static void Run()
        {
            char selection = EXIT;
            while ((selection = GameSelectionMenu()) != EXIT)
            {
                CreateGame(selection)
                    .Start()
                    .End();
            }
        }

        static char GameSelectionMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select your game:");
            Console.WriteLine("1. \"Four Digits Mastermind\"");
            Console.WriteLine("2. \"Six Digits Mastermind\"");
            Console.WriteLine("3. \"Number Master\"");
            Console.WriteLine("\"Any other key to EXIT\"");
            Console.WriteLine();
            Console.Write("Your choice: ");

            char userInput = Console.ReadKey(true).KeyChar;

            if (UserInputIsExit(userInput))
                return EXIT;
            else
                return userInput;
        }

        static bool UserInputIsExit(char userInput)
        {
            if (userInput != '1' && userInput != '2' && userInput != '3')
                return true;

            return false;
        }

        static IGame CreateGame(char selection) => selection switch
        {
            '1' => GameBuilder.ConsoleBuilder(SelectConsoleGame.FOUR_DIGITS_COWSANDBULLS),
            '2' => GameBuilder.ConsoleBuilder(SelectConsoleGame.SIX_DIGITS_COWSANDBULLS),
            '3' => GameBuilder.ConsoleBuilder(SelectConsoleGame.NUMBER_MASTER),
            _ => null
        };
    }
}
