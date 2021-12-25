using CleanCodeExam.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CleanCodeExamTEST.Logic
{
    [TestClass]
    public class FourDigitsLogicTest
    {
        //Act
        FourDigitsLogic logic = new FourDigitsLogic();

        [TestMethod]
        public void GetRightAnswer_ReturnBullsPattern()
        {
            //Arrange
            string expected = "BBBB";

            //Act
            string actual = logic.GetRightAnswer();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataRow("4598","1276", "")]
        [DataRow("4598","4598", "BBBB")]
        [DataRow("4598","8954", "CCCC")]
        [DataRow("4598","4589", "BBCC")]
        [DataRow("4598","1378", "B")]
        [DataRow("4598","5362", "C")]
        [DataRow("4598","4444", "BCCC")]
        [TestMethod]
        public void CompareResult_ReturnPatternsOfBullsAndCows(string goal, string userGuess, string expected)
        {
            //Arrange
            string actual = logic.CompareResult(goal, userGuess);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNewGoal_ReturnsFourDigitsString()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Act
                string actual = logic.CreateNewGoal();

                //Assert
                Assert.IsTrue(actual.Length == 4);
                Assert.IsTrue(Regex.Match(actual, @"\d{4,4}").Success); // All 4 are digits
                Assert.IsTrue(AllDifferentDigits(actual));
            }
        }

        bool AllDifferentDigits(string pattern)
        {
            char firstDigit = pattern.ToCharArray()[0];
            char secondDigit = pattern.ToCharArray()[1];
            char thirdDigit = pattern.ToCharArray()[2];
            char FourthDigit = pattern.ToCharArray()[3];

            if (firstDigit.Equals(secondDigit) || firstDigit.Equals(thirdDigit) || firstDigit.Equals(FourthDigit)) return false;
            if (secondDigit.Equals(thirdDigit) || secondDigit.Equals(FourthDigit)) return false;
            if (thirdDigit.Equals(FourthDigit)) return false;

            return true;
        }
    }
}
