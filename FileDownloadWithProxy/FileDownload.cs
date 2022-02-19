using System;
using System.IO;
using System.Text;
using System.Text.Json;

// ConnectProxy.ProxyConnection������
using System.Net;
using System.Net.Http;
// �桼�������������륯�饹
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
    // json�ƥ����Ȥ�json���֥������Ȥ˳�Ǽ
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
// �ץ��������Ф���³���륯�饹
// �ץ���ǧ�ھ����json �ե����뤫�����
namespace ConnectProxy
{
  class ProxyConnection
  {

    private HttpClientHandler ch;
    private HttpClient client;

    public void Connect(UserInfo data)
    {
      // HttpClientHandler��Proxy��������ꤹ��
      ch = new HttpClientHandler();
      ch.Proxy = new WebProxy(data.ProxyName);
      ch.Proxy.Credentials = new NetworkCredential(data.UserName, data.PassWord);
      ch.UseProxy = true;

      // HttpClientHandler���Ѥ���HttpClient������
      client = new HttpClient(ch);
    }

    public void RequestFile(string RequestUrl, string SaveFilePath)
    {
      try
      {
        // GET�ǥ쥹�ݥ󥹤����
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