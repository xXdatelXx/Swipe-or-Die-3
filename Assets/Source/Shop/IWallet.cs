public interface IWallet
{
    void Put(int money);
    bool CanTake(int money);
    void Take(int money);
}
