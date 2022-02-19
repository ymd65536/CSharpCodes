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
            string ErrorMessage = "�ե�����θ����˼���";
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(FolderPath, FileName, SearchOption.TopDirectoryOnly);
                return files.First();
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    ErrorMessage = "�����ե�����ѥ���" + FolderPath + "�פ����" + FileName + "�פ����Ĥ���ޤ���Ǥ�����";
                }
                else if (e.Message.Contains("Could not find a part of the path"))
                {
                    ErrorMessage = "�����ե�����ѥ���" + FolderPath + "�פ˸�꤬���뤫�ե����������ޤ���";
                }
            }
            return ErrorMessage;
        }
    }
}