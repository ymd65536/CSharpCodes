using System;

namespace FileSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string ProgramFile = FileSearch.SearchFile(args[0], args[1]);
            Console.WriteLine(ProgramFile);
        }
    }
}
