using CleanCodeExam.Interfaces;
using CleanCodeExam.Models;

namespace CleanCodeExam.Controllers
{
    public class MastermindGame : IGame
    {
        static MastermindGame SingletonCopy { get; set; } = null;

        ILogic _logic;
        IViews _views;
        IData _dataScore;

        string PlayerName { get; set; }
        string Goal { get; set; }
        string UserGuess { get; set; }
        int NumberOfTries { get; set; }

        string FOUR_BULLS { get; set; }

        public static MastermindGame Builder(ILogic gameLogic, IViews views, IData dataScore)
        {
            if (SingletonCopy == null)
                SingletonCopy = new MastermindGame(gameLogic, views, dataScore);

            return SingletonCopy;
        }

        private MastermindGame(ILogic gameLogic, IViews views, IData dataScore)
        {
            _logic = gameLogic;
            _views = views;
            _dataScore = dataScore;
            FOUR_BULLS = _logic.GetRightAnswer();
        }

        public void Start()
        {
            _views.ClearView();
            PlayerName = _views.EnterPlayerName();

            GameLoop();
        }

        void GameLoop()
        {
            ResetGame();
            _views.PrintInstructions(Goal);

            do
            {
                UserGuess = _views.EnterGuess();
                NumberOfTries++;
            } while (ResultOfUserGuess() != FOUR_BULLS);

            SaveAndPresentScore();

            if (_views.PlayAgain()) GameLoop();
        }

        void SaveAndPresentScore()
        {
            _dataScore.SaveScore(new Score(PlayerName, NumberOfTries));
            var listOfScores = _dataScore.GetScores();
            _views.PrintScore(listOfScores);
            _views.Congratulations(PlayerName, NumberOfTries);
        }

        string ResultOfUserGuess()
        {
            string result = _logic.CompareResult(Goal, UserGuess);
            _views.Showresult(result);
            return result;
        }

        void ResetGame()
        {
            UserGuess = "";
            Goal = _logic.CreateNewGoal();
            NumberOfTries = 0;
            _views.ClearView();
        }
    }
}
