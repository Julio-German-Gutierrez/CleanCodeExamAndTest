using CleanCodeExam.Interfaces;
using CleanCodeExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeExam.Views
{
    public class ConsoleViews : IViews
    {
        public string EnterPlayerName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        public void PrintInstructions(string goal)
        {
            Console.WriteLine("Try to Decypher the code:");
            //comment out or remove next line to play real games!
            Console.WriteLine("For practice, number is: " + goal);
        }

        public void Showresult(string result) => Console.WriteLine("Result: " + result);

        public void PrintScore(List<Score> scores)
        {
            if (scores != null) Console.WriteLine(OrganizeScoresToPrint(scores));
        }

        string OrganizeScoresToPrint(List<Score> scores)
        {
            string scoresOrganized = "TOP TEN SCORES:\n";

            foreach (var scoresByPlayer in scores.GroupBy(s => s.PlayerName))
            {
                string name = scoresByPlayer.Key.ToUpper();
                int tries = scoresByPlayer.Sum(s => s.NumberOfTries);
                double average = scoresByPlayer.Average(s => s.NumberOfTries);
                scoresOrganized += $"Name: {name,10} --- Tries: {tries,-3} --- Average: {average}\n";
            }
            return scoresOrganized;
        }

        public string EnterGuess()
        {
            Console.Write("Enter your guess: ");
            return Console.ReadLine();
        }
        public bool PlayAgain()
        {
            Console.Write("Do you want to play again? (Y/N) ");
            return char.ToUpper(Console.ReadKey(true).KeyChar).Equals('Y');
        }

        public void ClearView() => Console.Clear();

        public void Congratulations(string playerName, int numberOfTries) => Console.WriteLine($"Congratulations {playerName}, it took you {numberOfTries} guesses.");
    }
}
