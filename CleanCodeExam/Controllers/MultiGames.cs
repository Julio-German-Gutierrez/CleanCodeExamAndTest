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
        public void GameSelector()
        {
            int selection = GamesMenu();
            IGame newGame = CreateGame(selection);
            newGame.Start();
        }

        int GamesMenu()
        {
            Console.WriteLine("Please select your game:");
            Console.WriteLine("1. \"Four Digits Mastermind\"");
            Console.WriteLine("2. \"Six Digits Mastermind\"");
            Console.WriteLine("3. \"Number Master\"");
            Console.WriteLine();
            Console.WriteLine("Your choice: ");
            var response = Console.ReadKey(true).KeyChar.ToString();
            return int.Parse(response);
        }

        IGame CreateGame(int selection)
        {
            IGame game = null;
            switch (selection)
            {
                case 1:
                    {
                        return GameBuilder.ConsoleBuilder(SelectConsoleGame.FOUR_DIGITS_COWSANDBULLS);
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    break;
            }
            return null;
        }
    }
}
