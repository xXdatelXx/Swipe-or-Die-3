namespace Source.Model.Timer
{
    public interface IUpdatebles
    {
        void Add(IUpdateble updateble);
        void Remove(IUpdateble updateble);
    }
}