using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileManager_MP.Models
{
    public class FileDirectory
    {
        public string Path { get; set; }

        public string[] Files { get; set; }

        public string[] Directories { get; set; }

        public string Message { get; set; }


        public void GetDirectoryFiles(string path)
        {
            if (Directory.Exists(path))
            {
                Directories = Directory.GetDirectories(path);
                
                Files = Directory.GetFiles(path);
            }
        }

        public void DeleteFile()
        {
            Directory.Delete(Path, true);
        }

        public void CreateFile(string path)
        {
            try
            {
                FileStream fs = File.Create(path);
                Message = "File created successfully";
            }
            catch (Exception ex)
            {
                Message =  "File not created";
            }

        }
        public void CreateDirectory(string path)
        {

        }
    }
}