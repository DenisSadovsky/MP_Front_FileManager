using System;
using System.IO;

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
                return "Wrong path or empty directory";
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
                return "Deleted successfuly";

            }
            catch (Exception e)
            {
                return "Removal failed";
            }

        }

        public string CreateFile(string path)
        {
            try
            {
                File.Create(path);
                return "File created successfully";
            }
            catch (Exception ex)
            {
                return "File not created";
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