using System;
using System.IO;
using LocalRes = FileManager_MP.App_Resources.LocalResources;

namespace FileManager_MP.Services
{
    public class FileDirectoryServiceProvider : IFileDirectoryServiceProvider
    {
        public string GetDirectoryFiles(string path, out string[] directories, out string[] files)
        {
            if (!Directory.Exists(path))
            {
                directories = null;
                files = null;
                return LocalRes.WrongPathOrEmptyDirectory;
            }
            else
            {
                directories = Directory.GetDirectories(path);

                files = Directory.GetFiles(path);
                return null;
            }
        }

        public string DeleteFile(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    File.Delete(path);
                }
                Directory.Delete(path, true);
                return LocalRes.DeletedSuccessfuly;

            }
            catch (Exception e)
            {
                return LocalRes.RemovalFailed;
            }

        }

        public string CreateFile(string path)
        {
            try
            {
                File.Create(path);
                return LocalRes.FileCreatedSuccessfully;
            }
            catch (Exception ex)
            {
                return LocalRes.FileNotCreated;
            }

        }

        public string CreateDirectory(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                try
                {
                    dirInfo.Create();
                    return "Directory created successfully";
                }
                catch
                {
                    return "Directory not created";
                }
            }

            return "A directory exists or an invalid directory";
        }
    }
}