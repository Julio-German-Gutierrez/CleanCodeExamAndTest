/*
 * Implement this interface to create a new logic for MastermindGame
 */

namespace CleanCodeExam.Interfaces
{
    public interface ILogic
    {
        string CreateNewGoal();
        string CompareResult(string goal, string userGuess);
        string GetRightAnswer();
    }
}
