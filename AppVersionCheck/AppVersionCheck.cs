// ファイルのプロパティを参照
using System;
using System.Diagnostics;

namespace AppVersionCheck
{
    public class AppVersionCheck
    {
        public static string GetVersion(string FolderPath, string FileName)
        {
            // FileSearch.csからFileSearch メソッドを参照
            try
            {
                string ProgramFile = FileSearch.FileSearch.SearchFile(FolderPath, FileName);
                FileVersionInfo ProgramFileVersion = FileVersionInfo.GetVersionInfo(ProgramFile);

                return ProgramFileVersion.FileVersion;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}