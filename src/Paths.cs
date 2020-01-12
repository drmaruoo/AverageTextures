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

        public static List<string> GetAllPaths(string directory, filetypes filetype)
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

        public static int GetPathsCount(string directory, filetypes filetype)
        {
            return GetAllPaths(directory, filetype).Count;
        }
    }
}
