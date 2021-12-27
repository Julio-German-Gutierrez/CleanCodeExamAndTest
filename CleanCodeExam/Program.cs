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
            var cowAndBulls = GameBuilder
                .ConsoleBuilder(SelectConsoleGame.FOUR_DIGITS_COWSANDBULLS);

            cowAndBulls.Start();
        }
    }
}