/*
 * Implement this interface to create the interactive views for MastermindGame
 */

using CleanCodeExam.Models;
using System.Collections.Generic;

namespace CleanCodeExam.Interfaces
{
    public interface IViews
    {
        string EnterPlayerName();
        void PrintInstructions(string goal);
        void Showresult(string result);
        void PrintScore(List<Score> scores);
        string EnterGuess();
        bool PlayAgain();
        void ClearView();
        void Congratulations(string playerName, int numberOfTries);
    }
}
