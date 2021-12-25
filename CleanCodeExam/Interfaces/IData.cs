/*
 * Interface to provide data access for scores in MastermindGame
 */

using CleanCodeExam.Models;
using System.Collections.Generic;

namespace CleanCodeExam.Interfaces
{
    public interface IData
    {
        List<Score> GetScores();
        void SaveScore(Score newScore);
        void ResetScores();
    }
}
