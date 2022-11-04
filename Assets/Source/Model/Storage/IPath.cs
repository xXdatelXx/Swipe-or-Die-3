using System.IO;

namespace Source.Model.Storage
{
    public interface IPath
    {
        string Value { get; }
        Stream OpenFile();
    }
}