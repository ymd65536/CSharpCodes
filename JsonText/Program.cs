using System;
using System.IO;
using System.Text;
using System.Text.Json;

// プロキシ情報が書かれたJSONファイルをJSONオブジェクトに変換する。

namespace JsonText
{
    class Data {
        public string userName {get; set;}
        public string passWord {get; set;}
        public string proxyName {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            JsonText.Data jsonConfig = readJson(args[0],Encoding.GetEncoding(args[1]));
            if(!(jsonConfig == null)){
                Console.WriteLine("{0}",jsonConfig.userName);
            }
        }
        static void JsonSer()
        {
            Data data = new Data();
            string jsonStr = JsonSerializer.Serialize(data);
            Console.WriteLine(jsonStr);
        }
        // jsonテキストをjsonオブジェクトに格納
        static JsonText.Data readJson(string path,Encoding encType)
        {
            if (!File.Exists(path)){
                return null;
            }else{
                string jsonStr = File.ReadAllText(path, encType);
                Data jsonData = new Data();
                jsonData = JsonSerializer.Deserialize<Data>(jsonStr);
                return jsonData;
            }
        }
    }
}
