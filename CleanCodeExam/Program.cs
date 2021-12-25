using CleanCodeExam.Controllers;
using CleanCodeExam.Modules;
using CleanCodeExam.Views;
using System;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var cowAndBulls = new MastermindGame
                (
                    new FourDigitsLogic(),
                    new ConsoleViews(),
                    new FileData("Scores.txt")
                );

            cowAndBulls.Start();
        }
    }
}