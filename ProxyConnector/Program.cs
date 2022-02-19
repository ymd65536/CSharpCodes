using System;
using System.IO;
using System.Text;
using System.Text.Json;

// ConnectProxy.ProxyConnectionで利用
using System.Net;
using System.Net.Http;

namespace ProxyConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyInfo.ProxyConfig SetConfig = new ProxyInfo.ProxyConfig();
            UserInfo ConfigData = new UserInfo();
            ConfigData = SetConfig.ReadJson(args[0],Encoding.GetEncoding(args[1]));
            if(!(SetConfig == null)){
                Console.WriteLine("{0}",ConfigData.UserName);
                ConnectProxy.ProxyConnection ProCon = new ConnectProxy.ProxyConnection();
                ProCon.Connect(ConfigData);
                ProCon.RequestGet(ConfigData.RequestUrl);

            }
        }
    }
}


// ユーザ情報を定義するクラス
class UserInfo {
    public string UserName {get; set;}
    public string PassWord {get; set;}
    public string ProxyName {get; set;}
    public string RequestUrl {get; set;}
}
namespace ProxyInfo
{
    class ProxyConfig{
        // jsonテキストをjsonオブジェクトに格納
        public UserInfo ReadJson(string path,Encoding encType)
        {
            if (!File.Exists(path)){
                return null;
            }else{
                string jsonStr = File.ReadAllText(path, encType);
                UserInfo jsonData = new UserInfo();
                jsonData = JsonSerializer.Deserialize<UserInfo>(jsonStr);
                return jsonData;
            }
        }
    }
}
// プロキシサーバに接続するクラス
// プロキシ認証情報はjson ファイルから取得
namespace ConnectProxy{
    class ProxyConnection{
        
        private HttpClientHandler ch;
        private HttpClient client;

        public void Connect(UserInfo data){
            // HttpClientHandlerにProxy情報を設定する
            ch = new HttpClientHandler();
            ch.Proxy = new WebProxy(data.ProxyName);
            ch.Proxy.Credentials = new NetworkCredential(data.UserName,data.PassWord);
            ch.UseProxy = true;

            // HttpClientHandlerを用いてHttpClientを生成
            client = new HttpClient(ch);
        }

        public void RequestGet(string RequestUrl){
            try
            {
                // GETでレスポンスを取得
                var task = client.GetStringAsync(RequestUrl);
                task.Wait();
                Console.WriteLine(task.Result);
            }
            catch (Exception e)
            {
                Exception e2 = e.GetBaseException();
                System.Console.WriteLine(e2.Message);
            }
        }
    }
}


