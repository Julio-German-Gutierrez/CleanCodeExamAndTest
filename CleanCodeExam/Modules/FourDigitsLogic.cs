using CleanCodeExam.Interfaces;
using System;

namespace CleanCodeExam.Modules
{
    public class FourDigitsLogic : ILogic
    {
        string Bulls { get; set; }
        string Cows { get; set; }
        string Goal { get; set; }
        const int FOUR_DIGITS_GOAL = 4;
        const string RIGHT_ANSWER = "BBBB";

        public string GetRightAnswer() => RIGHT_ANSWER;
        public string CompareResult(string goal, string userGuess)
        {
            Bulls = "";
            Cows = "";
            for (int i = 0; i < goal.Length; i++)
            {
                for (int j = 0; j < userGuess.Length; j++)
                {
                    if (DigitsAreTheSame(goal[i], userGuess[j]))
                    {
                        SetBullsOrCows(i, j);
                    }
                }
            }
            return Bulls + Cows;
        }
        public string CreateNewGoal()
        {
            Goal = "";
            for (int i = 0; i < FOUR_DIGITS_GOAL; i++)
            {
                Goal += RandomNonRepetedDigit();
            }
            return Goal;
        }

        //private methods
        bool DigitsAreTheSame(char digitA, char digitB) => digitA.Equals(digitB);

        void SetBullsOrCows(int indexA, int indexB)
        {
            if (indexA == indexB) Bulls += "B";
            else Cows += "C";
        }

        //Until a maximum of 10 digits, for obvious reasons.
        string RandomNonRepetedDigit()
        {
            int number;
            do
            {
                number = new Random().Next(10);
            } while (Goal.Contains(number.ToString()));
            return number.ToString();
        }
    }
}
