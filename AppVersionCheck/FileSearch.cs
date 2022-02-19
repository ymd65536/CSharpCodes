using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearch
{
    public class FileSearch
    {
        public static string SearchFile(string FolderPath, string FileName)
        {
            string ErrorMessage = "ファイルの検索に失敗";
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(FolderPath, FileName, SearchOption.TopDirectoryOnly);
                return files.First();
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    ErrorMessage = "検索フォルダパス「" + FolderPath + "」から「" + FileName + "」が見つかりませんでした。";
                }
                else if (e.Message.Contains("Could not find a part of the path"))
                {
                    ErrorMessage = "検索フォルダパス「" + FolderPath + "」に誤りがあるかフォルダがありません。";
                }
            }
            return ErrorMessage;
        }
    }
}