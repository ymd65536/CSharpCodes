using System;
using System.IO;
using System.Text;
using System.Text.Json;

// ConnectProxy.ProxyConnectionで利用
using System.Net;
using System.Net.Http;
// ユーザ情報を定義するクラス
class UserInfo
{
  public string UserName { get; set; }
  public string PassWord { get; set; }
  public string ProxyName { get; set; }
  public string RequestUrl { get; set; }
}
namespace ProxyInfo
{
  class ProxyConfig
  {
    // jsonテキストをjsonオブジェクトに格納
    public UserInfo ReadJson(string path, Encoding encType)
    {
      if (!File.Exists(path))
      {
        return null;
      }
      else
      {
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
namespace ConnectProxy
{
  class ProxyConnection
  {

    private HttpClientHandler ch;
    private HttpClient client;

    public void Connect(UserInfo data)
    {
      // HttpClientHandlerにProxy情報を設定する
      ch = new HttpClientHandler();
      ch.Proxy = new WebProxy(data.ProxyName);
      ch.Proxy.Credentials = new NetworkCredential(data.UserName, data.PassWord);
      ch.UseProxy = true;

      // HttpClientHandlerを用いてHttpClientを生成
      client = new HttpClient(ch);
    }

    public void RequestFile(string RequestUrl, string SaveFilePath)
    {
      try
      {
        // GETでレスポンスを取得
        // var task = client.GetStringAsync(RequestUrl);
        var task = client.GetAsync(RequestUrl);
        task.Wait();

        var stream = task.Result.Content.ReadAsStreamAsync();
        var fileStream = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        stream.Result.CopyTo(fileStream);

      }
      catch (Exception e)
      {
        Exception e2 = e.GetBaseException();
        System.Console.WriteLine(e2.Message);
      }
    }
  }
}