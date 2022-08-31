public struct Score
{
    public int Value { get; private set; }

    public void Append()
    {
        Value++;
    }
}
