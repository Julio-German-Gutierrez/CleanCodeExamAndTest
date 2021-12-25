using CleanCodeExam.Controllers;
using CleanCodeExam.Interfaces;
using CleanCodeExam.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamTEST.GameFlow
{
    [TestClass]
    public class MastermindGameTest
    {
        [TestMethod]
        public void Start_FullTestWithFakeObjects()
        {
            for (int i = 0; i < 100; i++)
            {
                //Arrange
                Exception error = null;
                MastermindGame game = new MastermindGame
                    (
                        new FourDigitsLogicFake(),
                        new ConsoleViewsFake(),
                        new FileDataFake()
                    );

                //Act
                try
                {
                    game.Start();
                }
                catch (Exception e)
                {
                    error = e;
                }

                //Assert
                Assert.IsNull(error); 
            }
        }
    }

    class ConsoleViewsFake : IViews
    {
        public void ClearView()
        {
        }

        public void Congratulations(string playerName, int numberOfTries)
        {
        }

        public string EnterGuess()
        {
            string[] userGuess = new string[] {"4562","9854","3647","7516","9468","9845"};
            int index = new Random().Next(userGuess.Length);
            return userGuess[index];
        }

        public string EnterPlayerName()
        {
            string[] names = new string[]{"Polaris","Pollux","Sirius","Bellatrix","Betelgeuse"};
            int index = new Random().Next(names.Length);
            return names[index];
        }

        public bool PlayAgain() => new Random().Next(10) > 5 ? true : false;

        public void PrintInstructions(string goal)
        {
        }

        public void PrintScore(List<Score> scores)
        {
        }

        public void Showresult(string result)
        {
        }
    }

    class FourDigitsLogicFake : ILogic
    {
        public string CompareResult(string goal, string userGuess) => goal.Equals(userGuess) ? "BBBB" : "BBCC";

        public string CreateNewGoal() => "9845";

        public string GetRightAnswer() => "BBBB";
    }

    class FileDataFake : IData
    {
        public List<Score> GetScores()
        {
            return new List<Score>
            {
                new Score("Caponi", 23),
                new Score("Maroni", 5),
                new Score("Elliot", 17),
                new Score("Nessi", 7),
                new Score("Capanga", 18)
            };
        }

        public void ResetScores()
        {
        }

        public void SaveScore(Score newScore)
        {
        }
    }
}
