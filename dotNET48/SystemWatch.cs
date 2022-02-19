/*
アプリケーションを制御するクラスを作成する。
機能1:指定したアプリケーションが起動されているかを確認する。
機能2:指定したアプリケーションを起動する。
機能3:指定したアプリケーションを閉じる。
*/
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace SystemsManager
{
  public class AppManager{
    Process[] localAll;
    Process StartProcessObj;
    Process GetProcessObj;

    //ProcessStartInfo StartInfo;
    int process_cnt;

    // 指定したプロセスを取得する。
    public void GetProcess(string process_title){
      Process[] ShowProcesses = Process.GetProcesses();
      foreach (Process ShowProcess in ShowProcesses)
      {
        if(process_title == ShowProcess.ProcessName){
          Console.WriteLine(ShowProcess.ProcessName);
          this.GetProcessObj = ShowProcess;
          break;
        }
      }
    }

    // 現在実行されているプロセスをすべて取得する。
    public void setProcessAll(){
      this.localAll = Process.GetProcesses();
    }

    // 現在実行されているプロセスを返す。(クラスのプロパティから返す。)
    public Process[] getProcessAll(){
      return this.localAll;
    }

    // 現在実行されているプロセスを格納したコレクションの長さを返す。
    public int getProcessAllLength(){
      return this.localAll.Length;
    }

    // 指定したプロセスが存在するかをProcessオブジェクトの長さで返す。
    public int getProcessName(string process_title){
      try
      {
        this.process_cnt = Process.GetProcessesByName(process_title).Length;
      }
      catch (Exception ex)
      {
         // TODO
         Console.WriteLine(ex.Message);
      }
      return process_cnt;

    }

    // 指定したプロセスを起動する。
    public void StartProcess(string execute_process_title){
      try
      {
        this.StartProcessObj = Process.Start(execute_process_title);
        Console.WriteLine("プロセスをスタートします。:{0}",this.StartProcessObj.Id);
      }
      catch (Win32Exception e)
      {
         // TODO
         Console.WriteLine(e.Message);
      }
    }

    // プロセス コンポーネントにキャッシュされている関連付けられたプロセスに関するすべての情報を破棄します。
    public void Refresh(){
      try
      {
        this.StartProcessObj.Refresh();
      }
      catch (Exception ex)
      {
         // TODO
         Console.WriteLine(ex.Message);
      }
    }

    // 指定のウィンドウを閉じる。
    public void CloseMainWindow(){
      try
      {
        Console.WriteLine("ウィンドウをクローズします。:{0}",this.StartProcessObj.Id);
        this.StartProcessObj.CloseMainWindow();
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
    }

    // 指定したプロセスを閉じる。
    public void CloseProcess(){
      try
      {
        Console.WriteLine("プロセスをクローズします。:{0}",this.StartProcessObj.Id);
        this.StartProcessObj.Close();
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
    }

    // プロセス強制終了
    public void KillProcess(int s_time = 0){
      Console.WriteLine("{0} 秒待機",s_time / 1000);
      Thread.Sleep(s_time);
      try
      {
        Console.WriteLine("プロセスを強制終了します。:{0}",this.GetProcessObj.Id);
        this.GetProcessObj.Kill();
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
    }

    // 起動中のプロセスを一覧にして表示する。
    public void ShowProcessCollection(){
      Process[] ShowProcesses = Process.GetProcesses();
      foreach (Process ShowProcess in ShowProcesses)
      {
        Console.WriteLine(ShowProcess.ProcessName);
      }
    }

  }
}