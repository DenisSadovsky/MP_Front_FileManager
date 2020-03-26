

namespace FileManager_MP.Services
{
    public interface IFileDirectoryServiceProvider
    {
        string GetDirectoryFiles(string path, out string[] directories, out string[] files);

        string DeleteFile(string path);

        string CreateFile(string path);

        string CreateDirectory(string path);

    }
}
