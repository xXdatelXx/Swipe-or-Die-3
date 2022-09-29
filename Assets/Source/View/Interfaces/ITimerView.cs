namespace SwipeOrDie.View
{
    public interface ITimerView
    {
        void OnSetTime(float percent, float time);
        void OnEndTime();
    }
}