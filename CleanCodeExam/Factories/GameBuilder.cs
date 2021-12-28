using CleanCodeExam.Controllers;
using CleanCodeExam.Interfaces;
using CleanCodeExam.Modules;
using CleanCodeExam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExam.Factories
{
    public static class GameBuilder
    {
        public static IGame ConsoleBuilder(SelectConsoleGame gameSelected)
        {
            switch (gameSelected)
            {
                case SelectConsoleGame.FOUR_DIGITS_COWSANDBULLS:
                    {
                        return MastermindGame.Builder
                            (
                                new FourDigitsLogic(),
                                new ConsoleViews(),
                                new FileData("Scores.txt")
                            );
                    }
                case SelectConsoleGame.SIX_DIGITS_COWSANDBULLS:
                    {
                        return MastermindGame.Builder
                            (
                                new SixDigitsLogic(),
                                new ConsoleViews(),
                                new FileData("ScoresSix.txt")
                            );
                    }
                case SelectConsoleGame.NUMBER_MASTER:
                    {
                        return NumberMaster.Builder();
                    }
                default:
                    return null;
            }
        }
    }

    public enum SelectConsoleGame
    {
        FOUR_DIGITS_COWSANDBULLS,
        SIX_DIGITS_COWSANDBULLS,
        NUMBER_MASTER
    }
}
