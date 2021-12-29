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
                var game = CreateGame(selection);
                if (game != null)
                    game.Start().End();
            }
        }

        static char GameSelectionMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select your game:");
            Console.WriteLine("1. \"Four Digits Mastermind\"");
            Console.WriteLine("2. \"Six Digits Mastermind\"");
            Console.WriteLine("3. \"Number Master\"");
            Console.WriteLine("4. \"EXIT\"");
            Console.WriteLine();
            Console.Write("Your choice: ");

            return Console.ReadKey(true).KeyChar;
        }

        static IGame CreateGame(char selection) => selection switch
        {
            '1' => GameBuilder.ConsoleBuilder(SelectConsoleGame.FOUR_DIGITS_COWSANDBULLS),
            '2' => GameBuilder.ConsoleBuilder(SelectConsoleGame.SIX_DIGITS_COWSANDBULLS),
            '3' => GameBuilder.ConsoleBuilder(SelectConsoleGame.NUMBER_MASTER),
             _  => null
        };
    }
}
