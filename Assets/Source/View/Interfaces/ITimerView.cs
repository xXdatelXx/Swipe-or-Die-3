namespace SwipeOrDie.View
{
    public interface ITimerView
    {
        void OnSetTime(float time, float percent = 100);
        void OnEndTime();
    }
}