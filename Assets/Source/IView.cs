namespace Source
{
    public interface IView<T>
    {
        void View(T value);
    }

    public interface IView
    {
        void View();
    }
}