namespace CleanCodeExam.Models
{
    public class Score
    {
        public string PlayerName { get; private set; }
        public int NumberOfTries { get; private set; }

        public Score(string name, int numberOfTries)
        {
            PlayerName = name;
            NumberOfTries = numberOfTries;
        }

        public override string ToString() => $"{PlayerName}#&#{NumberOfTries}\n";
    }
}
