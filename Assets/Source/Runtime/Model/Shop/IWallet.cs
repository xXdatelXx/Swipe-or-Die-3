namespace SwipeOrDie.Model
{
    public interface IWallet
    {
        int Money { get; }
        void Put(int money = 1);
        bool CanTake(int money);
        void Take(int money);
    }
}