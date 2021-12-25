using CleanCodeExam.Models;
using CleanCodeExam.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamTEST.DataAccess
{
    [TestClass]
    public class FileDataTest
    {
        [TestMethod]
        [DataRow(@"T:\Scores.txt")]
        [DataRow(@"Z:\1Scores.txt")]
        [DataRow(@"http://Scores.txt")]
        [DataRow(@"Cacho\\Scores.txt")]
        [DataRow(@"/cualquiera/?Scores.txt")]
        public void GetScores_DoNotThrowExceptions(string path)
        {
            //Arrange
            FileData fileData = new FileData(path);
            Exception error = null;

            //Act
            try
            {
                List<Score> actual = fileData.GetScores();
            }
            catch (Exception e)
            {
                error = e;
            }

            //Assert
            Assert.IsNull(error);
        }

        [TestMethod]
        public void GetScores_ReturnList()
        {
            //Arrange
            //string path = @"C:\German repos\CleanCode\CodeCleanExam\bin\Debug\net5.0\Scores.txt"; //real file
            string path = Environment.CurrentDirectory + @"\LocalScores.txt";
            FileData fileData = new FileData(path);
            Score score = null;

            //Act
            List<Score> actual = fileData.GetScores();
            score = actual[0];

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(List<Score>));
            Assert.AreEqual(score.PlayerName, "German");
            Assert.AreEqual(score.NumberOfTries, 6);
        }

        [TestMethod]
        [DataRow(@"T:\Scores.txt")]
        [DataRow(@"Z:\1Scores.txt")]
        [DataRow(@"http://Scores.txt")]
        [DataRow(@"Cacho\\Scores.txt")]
        [DataRow(@"/cualquiera/?Scores.txt")]
        public void SaveScore_DoNotThrowExceptions(string path)
        {
            //Arrange
            FileData fileData = new FileData(path);
            Exception error = null;
            Score testScore = new Score("Matu", 5);

            //Act
            try
            {
                fileData.SaveScore(testScore);
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
