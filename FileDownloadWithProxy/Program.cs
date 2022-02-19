using System;
using System.Text;

namespace HttpClientTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            ProxyInfo.ProxyConfig SetConfig = new ProxyInfo.ProxyConfig();

            UserInfo ConfigData = new UserInfo();

            ConfigData = SetConfig.ReadJson(args[0], Encoding.GetEncoding(args[1]));
            if (!(SetConfig == null))
            {
                ConnectProxy.ProxyConnection ProCon = new ConnectProxy.ProxyConnection();
                ProCon.Connect(ConfigData);
                ProCon.RequestFile(ConfigData.RequestUrl, args[2]);
            }
        }
    }
}
