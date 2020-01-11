using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AverageTextures
{
    public class Paths
    {
        public enum filetypes
        {
            png,
            bmp,
            txt
        }
        public static List<FileInfo> getFileInfoList(string directory, filetypes filetype)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            List<string> paths = getAllPaths(directory, filetype);
            foreach (string path in paths)
            {
                fileInfos.Add(new FileInfo(path));
            }
            return fileInfos;
        }
        public static List<string> getAllPaths(string directory, filetypes filetype)
        {
            try
            {
                List<string> paths = new List<string>();
                paths = Directory.GetFiles(directory, "*." + filetype, SearchOption.AllDirectories).ToList();
                return paths;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static int getPathsCount(string directory, filetypes filetype)
        {
            return getAllPaths(directory, filetype).Count;
        }
    }
}
