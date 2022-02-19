using System;
using System.IO;
using System.Text;

// 拡張機能(自作)
using SystemsManager;

namespace app{
  class ProcessManager{
    static void Main(string[] args){
      if(args.Length > 2){
        Console.WriteLine("引数が多すぎます。");
      }
      if(args.Length < 2){
        Console.WriteLine("引数が足りません。");
      }
      // 引数が2つなら実行する。
      if (args.Length == 2){
        AppManager AppObj = new AppManager();
        // 引数で指定したプログラムが起動されていない場合は起動する。
        if(AppObj.getProcessName(args[0]) < 1){
          AppObj.StartProcess(args[0]);
        }
      }
    }
  }
}