namespace SwipeOrDie.Extension
{
    public static class RandomExtension
    {
        public static float Percent(this System.Random random) => random.Next(0, 100);
    }
}