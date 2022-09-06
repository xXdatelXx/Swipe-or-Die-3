namespace SwipeOrDie.GameLogic
{
    public class Score : IScore
    {
        public int Value { get; private set; }

        public void Append()
        {
            Value++;
        }
    }
}
