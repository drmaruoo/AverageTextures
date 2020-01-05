using System;
using System.Collections.Generic;

namespace AverageTextures
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory;
            Paths.filetypes filetype;
            Console.WriteLine("AverageTextures - change all pictures within a directory to a solid-filled with their initial average color ones.");
            Console.WriteLine("By Marcin 'drmaruoo' Domarski - 2020");
            Console.WriteLine("");
            Console.WriteLine("Please enter the directory:");
            directory = Console.ReadLine();
            Console.WriteLine("png/bmp?");
            filetype = (Paths.filetypes)Enum.Parse(typeof(Paths.filetypes), Console.ReadLine()); //dirty, to be reworked in the near future
            List<string> paths = Paths.getAllPaths(directory, filetype);
            foreach (string path in paths)
            {
                Console.WriteLine(path);
                ImageProcessor.averageAndSaveBitmapToPath(path);
            }
            Console.WriteLine("Done to " + Paths.getPathsCount(directory, filetype));
            Console.ReadLine();
        }
    }
}
