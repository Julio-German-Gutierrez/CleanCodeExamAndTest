using CleanCodeExam.Controllers;
using CleanCodeExam.Factories;
using CleanCodeExam.Modules;
using CleanCodeExam.Views;
using System;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var multiGames = new MultiConsoleGames();
            multiGames.GameSelector();
        }
    }
}