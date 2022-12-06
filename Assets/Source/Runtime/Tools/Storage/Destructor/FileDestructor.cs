using System.IO;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Storage
{
    public sealed class FileDestructor : IFileDestructor
    {
        private readonly IPath _path;

        public FileDestructor(string path) : this(new Path(path))
        { }

        public FileDestructor(IPath path) => 
            _path = path.ThrowExceptionIfArgumentNull(nameof(path));

        public void Destruct() => File.Delete(_path.Value);
    }
}