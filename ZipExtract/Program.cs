using System;
using System.IO;
using System.IO.Compression;

namespace ZipExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = args[0];
            string extractPath = args[1];

            Console.WriteLine("zipファイルの解凍開始！！：" + zipPath);
            Console.WriteLine(args[0] + "=>" + args[1]);

            try
            {
                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true);
                }
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch
            {
                Console.WriteLine("解凍に失敗しました。");
            }

            Console.WriteLine("終了！！");
        }
    }
}
