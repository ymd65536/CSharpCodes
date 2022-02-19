using System;

namespace AppVersionCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppVersionCheck.GetVersion(args[0], args[1]));
        }
    }
}
