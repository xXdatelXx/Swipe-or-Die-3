namespace SwipeOrDie.Model
{
    public interface IWallet
    {
        void Put(int money = 1);
        bool CanTake(int money);
        void Take(int money);
    }
}