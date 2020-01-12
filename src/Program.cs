using System;
using System.Collections.Generic;

namespace AverageTextures
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory;
            string destination;
            Paths.filetypes filetype;
            Console.WriteLine("AverageTextures - change all pictures within a directory to a solid-filled with their initial average color ones.");
            Console.WriteLine("By Marcin 'drmaruoo' Domarski - 2020");
            Console.WriteLine("");
            Console.WriteLine("Please enter the directory:");
            directory = Console.ReadLine();
            Console.WriteLine("png/bmp?");
            filetype = (Paths.filetypes)Enum.Parse(typeof(Paths.filetypes), Console.ReadLine()); //dirty, to be reworked in the near future
            Console.WriteLine("Please enter the folder destination path:");
            destination = Console.ReadLine();
            List<string> paths = Paths.GetAllPaths(directory, filetype);
            foreach (string path in paths)
            {
                Console.WriteLine(path);
                ImageProcessor.AverageAndSaveBitmapToPath(path);
            }
            Console.WriteLine("Done to " + Paths.GetPathsCount(directory, filetype));
            Console.ReadLine();
        }
    }
}
