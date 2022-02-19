using System;
using Renci.SshNet;

namespace ssh_terminal
{
  class SshConnObj
  {
    
    private string userName;
    private string passWord;
    private string hostName;
    private int portNo;

    private ConnectionInfo connInfo;
    private SshClient sshClient;
    private SshCommand CmdObj;

    private string CmdResult;
    private string CmdError;
    private bool IsStd;

    // 接続文字列を定義
    public void setConnectionString(string username,string password ,string host,int portno=22)
    {
      userName = username;
      passWord = password;
      hostName = host;
      portNo = portno;
      return;
    }
    // ConnectionInfoオブジェクトを生成
    public void SetConnectionObj()
    {
      connInfo = new ConnectionInfo(hostName,portNo,userName,
        new AuthenticationMethod[] {
          new PasswordAuthenticationMethod(userName,passWord)
              /* PrivateKeyAuthenticationMethod("キーの場所")を指定することでssh-key認証にも対応しています */
          }
      );
      return;
    }
    
    // SSHクライアントを作成
    public void SshClientObj()
    {
      sshClient = new SshClient(connInfo);
    }

    // SSH接続
    public void SshConnect()
    {
      sshClient.Connect();
    }

    // SSHを切断
    public void SshDisconnect()
    {
      sshClient.Disconnect();
    }

    // コネクションの状態を返す。
    public bool IsConnected()
    {
      return sshClient.IsConnected;
    }

    // 指定の文字列を投入 SshCommand オブジェクトを使う
    public void CmdExecute(String CmdText) {
      CmdObj = sshClient.CreateCommand(CmdText);
      CmdObj.Execute();
      CmdResult = CmdObj.Result;
      CmdError = CmdObj.Error;
    }

    // 終了コードを返す。
    public int CmdEndCode()
    {
      return CmdObj.ExitStatus;
    }

    // 標準出力があるかどうかを返す
    public bool IsStdOut()
    {
      IsStd = CmdResult != string.Empty;
      return IsStd;
    }

    // 標準出力を表示する
    public string StdPrint()
    {
      return IsStd  ? CmdResult : "";
    }

    // エラーがあるかどうかを返す
    public bool IsStdError()
    {
      IsStd = CmdObj.ExitStatus != 0 && CmdError != string.Empty;
      return IsStd;
    }

    // エラー出力を表示する
    public string StdError()
    {
      return IsStd ? CmdError : "";
    }



  }
}
