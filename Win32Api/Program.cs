using System.Text;
using System.Diagnostics;
using Win32;

static bool EnumChildWindowsProc(IntPtr hWnd, IntPtr lParam)
{
  var count = WinNative.GetWindowTextLength(hWnd);
  var sb = new StringBuilder(500);
  var ret = WinNative.GetWindowText(hWnd, sb, 500);

  StringBuilder className = new(500);
  IntPtr ChildHwnd = hWnd;
  int ChildRet = WinNative.GetClassName(ChildHwnd, className, 500);

  StringBuilder TitleName = new(500);

  int ChildTitle = WinNative.GetWindowText(ChildHwnd, TitleName, 500);

  Console.WriteLine("{0} 0x{1:X8} - {2} {3} {4}", new string('+', lParam.ToInt32()), hWnd.ToInt32(), sb.ToString(), className, TitleName);

  // さらに自身の子ウインドウを列挙
  WinNative.EnumChildWindows(hWnd, EnumChildWindowsProc, new IntPtr(lParam.ToInt32() + 1));

  return true;
}

IntPtr hwnd;


//全てのプロセスを列挙する
foreach (Process p in
    Process.GetProcesses())
{
  //メインウィンドウのタイトルがある時だけ列挙する
  if (p.MainWindowTitle.Length != 0)
  {
    if (p.ProcessName == "LegacyBrowser")
    {
      Console.WriteLine("プロセス名:" + p.ProcessName);
      Console.WriteLine("タイトル名:" + p.MainWindowTitle);
      hwnd = p.MainWindowHandle;

      int length = WinNative.GetWindowTextLength(hwnd);
      WinNative.EnumChildWindows(hwnd, EnumChildWindowsProc, new IntPtr(1));
      StringBuilder className = new(500);
      int ret = WinNative.GetClassName(hwnd, className, 500);

      Console.WriteLine(className);
      Console.WriteLine("");
    }
  }
}