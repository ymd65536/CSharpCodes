using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;

namespace csv_table
{
    class Program
    {
        static void Main(string[] args)
        {
            // Shift_JISを扱う為
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            StreamReader FileStreamObj;
            StreamReader CsvFileStreamObj;
            StreamWriter OutPutCsvFileObj;
            
            Encoding FileEncordObj;
            Encoding InputFileEncordObj;
            Encoding OutputFileEncordObj;

            // 引数取得
            string JsonFilePath = args[0];
            string FileEncoding = args[1];

            string InputCsvFilePath = args[2];
            string InputCsvFileEncode = args[3];

            string OutputCsvFilePath = args[4];
            string OutputCsvFileEncode = args[5];

            string JsonConfigText = "";

            string OutputText = "";

            // 文字コードを設定
            FileEncordObj = Encoding.GetEncoding(FileEncoding);
            InputFileEncordObj = Encoding.GetEncoding(InputCsvFileEncode);
            OutputFileEncordObj = Encoding.GetEncoding(OutputCsvFileEncode);

            // ストリームに出力
            FileStreamObj = new StreamReader(JsonFilePath,FileEncordObj);

            // ファイルを読み込み
            JsonConfigText = FileStreamObj.ReadToEnd();

            // JSONオブジェクトに変換
            JsonDocument JsonObj = JsonDocument.Parse(JsonConfigText);
            var config = JsonObj.RootElement.GetProperty("column_names");

            // 変換対象となるCSVを入力
            CsvFileStreamObj = new StreamReader(InputCsvFilePath,InputFileEncordObj);

            // TextFieldParserを使う
            var parser = new TextFieldParser(CsvFileStreamObj);

            //CsvFileStreamObj.Close();

            // カンマ区切りの指定
            parser.SetDelimiters(",");

            // フィールドが引用符で囲まれているか
            parser.HasFieldsEnclosedInQuotes = true;

            // フィールドの空白トリム設定
            //parser.TrimWhiteSpace = true;

            // 先頭行をファイルのヘッダとして認識
            string[] items = parser.ReadFields();

            // カラム番号を保存しておく変数
            int num = 0;

            // カラム名を保存しておく変数
            string name = "";

            // カラムが一致していない場合のエラーカウント
            int ErrCount  = 0;

            int ColCnt = 0;

            // JSONからCSVのスキーマを取得して表示
            for(int cnt = 0;cnt < config.GetArrayLength();cnt++){
                num = config[cnt].GetProperty("num").GetInt32();
                name = config[cnt].GetProperty("name").GetString();

                // 先頭行にJSONで指定したカラムがあるか確認
                if(items[num]==name){
                    //Console.WriteLine(name + ":OK");
                    ColCnt = ColCnt + 1;
                }else{
                    //Console.WriteLine(name + ":NG");
                    ErrCount = ErrCount + 1;
                }
            }

            // 指定したカラムが一つでもなければ、異常終了
            if(ErrCount > 0){
                return ;
            }else{

                string[] HeaderAry = new string[ColCnt];
                string[] TableBody = new string[ColCnt];
                string Header ="";

                for(int cnt = 0;cnt < config.GetArrayLength();cnt++){
                    num = config[cnt].GetProperty("num").GetInt32();
                    name = config[cnt].GetProperty("name").GetString();
                    HeaderAry[num] = "\"" + name + "\"";
                }
                // 指定したカラムがすべてあるならば、ヘッダ情報をファイルに出力
                Header = String.Join(",",HeaderAry) + "\r\n";

                // JSONで指定したカラムのみCSVで出力 - 2行目以降
                while (!parser.EndOfData)
                {
                    items = parser.ReadFields();
                    for(int cnt = 0;cnt < config.GetArrayLength();cnt++){
                        num = config[cnt].GetProperty("num").GetInt32();
                        TableBody[num] = "\"" + items[num] + "\"";
                    }
                    OutputText =  OutputText + String.Join(",",TableBody) + "\n";
                    // Array.ForEach(items, p => Console.Write($"[{p}] "));
                }

                OutPutCsvFileObj = new StreamWriter(OutputCsvFilePath,false,OutputFileEncordObj);
                OutPutCsvFileObj.Write(Header + OutputText);
                OutPutCsvFileObj.Close();

                // ファイルを閉じる
                FileStreamObj.Close();
            }



        }
    }
}
