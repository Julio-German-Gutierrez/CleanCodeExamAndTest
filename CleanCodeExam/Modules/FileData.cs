using CleanCodeExam.Interfaces;
using CleanCodeExam.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace CleanCodeExam.Modules
{
    public class FileData : IData
    {
        string FilePath { get; set; }
        const string SEPARATOR = "#&#";
        const int NAME = 0;
        const int TRIES = 1;

        public FileData(string filePath)
        {
            FilePath = filePath;
        }
        public List<Score> GetScores()
        {
            try
            {
                var arrayOfScores = File.ReadAllLines(FilePath);
                return ArrayOfScoresToList(arrayOfScores);
            }
            catch
            {
                return null;
            }
        }

        public void ResetScores()
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);
        }

        public void SaveScore(Score newScore)
        {
            try
            {
                File.AppendAllText(FilePath, newScore.ToString());
            }
            catch
            {
            }
        }

        List<Score> ArrayOfScoresToList(string[] arrayOfScores)
        {
            var listOfScores = new List<Score>();
            foreach (var score in arrayOfScores)
            {
                string[] nameAndTries = score.Split(SEPARATOR);
                string playerName = nameAndTries[NAME];
                int numberOfTries = int.Parse(nameAndTries[TRIES]);
                listOfScores.Add(new Score(playerName, numberOfTries));
            }
            return listOfScores;
        }
    }
}
