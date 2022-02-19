using System;

namespace ssh_terminal{
  class Program{
    static void Main(string[] args){
      try
      {
        SshConnObj TestClientObj = new SshConnObj();

        // ログインユーザー名
        string userName = args[0];

        // ログインパスワード
        string passWord = args[1];

        // 接続先のホスト名またはIPアドレス
        string hostNameOrIpAddr = "localhost";

        // 接続先のポート番号
        int portNo = 20021;

        // クライアント作成
        TestClientObj.setConnectionString(userName
          ,passWord,hostNameOrIpAddr,portNo);
        TestClientObj.SetConnectionObj();
        TestClientObj.SshClientObj();

        // 接続開始
        TestClientObj.SshConnect();

        if (TestClientObj.IsConnected())
        {
          // 接続に成功した（接続状態である）
          Console.WriteLine("[OK] SSH Connection succeeded!!");
        }
        else
        {
          // 接続に失敗した（未接続状態である）
          Console.WriteLine("[NG] SSH Connection failed!!");
          return;
        }

        while (TestClientObj.IsConnected())
        {
          Console.Write("{0}@{1}# ", userName, hostNameOrIpAddr);
          
          // 送信したいコマンドを変数に入れて実行
          string commandString = Console.ReadLine();

          if (commandString == "exit")
          {
            break;
          }

          if (!(commandString == string.Empty))
          {
            TestClientObj.CmdExecute(commandString);
            // 標準出力を表示する
            if (TestClientObj.IsStdOut())
            {
              Console.Write(TestClientObj.StdPrint());
              // 終了コードを表示する
            }

            // エラー出力を表示する
            if (TestClientObj.IsStdError())
            {
              Console.Write(TestClientObj.StdError());
            }
            // Console.WriteLine("終了コード:{0}", TestClientObj.CmdEndCode());
          }
        }

        // 接続終了
        TestClientObj.SshDisconnect();
      }
      catch (Exception ex)
      {
        // エラー発生時
        Console.WriteLine(ex.Message);
        throw ex;
      }
    }
  }
}
