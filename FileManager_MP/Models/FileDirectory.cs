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


        public void GetDirectoryFiles()
        {
            if (!Directory.Exists(Path))
            {
                Message = "Wrong path or empty directory";
            }
            else
            {
                Directories = Directory.GetDirectories(Path);

                Files = Directory.GetFiles(Path);
            }
        }

        public void DeleteFile()
        {
            try
            { 
                if (!Directory.Exists(Path))
                {
                    File.Delete(Path);
                }
                Directory.Delete(Path, true);
                Message = "Deleted successfuly";

            }
            catch (Exception e)
            {
                Message = "Removal failed";
            }
           
        }

        public void CreateFile()
        {
            try
            {
                File.Create(Path);
                Message = "File created successfully";
            }
            catch (Exception ex)
            {
                Message =  "File not created";
            }

        }
        public void CreateDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            if (!dirInfo.Exists)
            {
                try
                {
                    dirInfo.Create();
                    Message = "Directory created successfully";
                }
                catch
                {
                    Message = "Directory not created";
                }

                
            }
        }
    }
}