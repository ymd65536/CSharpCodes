using System;
using System.Net;

namespace FileRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            string RemoteFile = args[0];
            string SaveFilePath = args[1];

            try
            {
                // WebClient リソース
                WebClient myWebClient = new WebClient();

                // ファイルのダウンロードを開始 を通知
                Console.WriteLine("ダウンロード開始 \"{0}\" from \"{1}\" .......\n\n", SaveFilePath, RemoteFile);

                // ファイルのダウンロード
                myWebClient.DownloadFile(RemoteFile, SaveFilePath);

                // ファイルのダウンロードを通知
                Console.WriteLine("ダウンロード完了 \"{0}\" from \"{1}\"", SaveFilePath, RemoteFile);

            }
            catch
            {
                Console.WriteLine("ファイルのダウンロードに失敗しました。");
            }
        }
    }
}
