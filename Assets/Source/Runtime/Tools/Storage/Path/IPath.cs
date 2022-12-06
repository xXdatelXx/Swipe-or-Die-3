using System.IO;

namespace SwipeOrDie.Storage
{
    public interface IPath
    {
        string Value { get; }
        Stream OpenFile();
    }
}