using SwipeOrDie.GameLogic;

namespace Source.Model
{
    public interface IMaxScore
    {
        bool Exists();
        IScore Load();
        void TrySave();
    }
}