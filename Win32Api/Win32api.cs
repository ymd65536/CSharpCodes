using System.Runtime.InteropServices;
using System.Text;

namespace Win32
{
  class WinNative
  {
    private const string IID_IHTMLDocument2 = "{332c4425-26cb-11d0-b483-00c04fd90119}";
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool EnumChildWindows(
        IntPtr hWndParent,
        EnumWindowsProc lpEnumFunc,
        IntPtr lParam
    );

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowTextLength(IntPtr hwnd);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern Int32 GetWindowText(
        IntPtr hWnd,
        StringBuilder lpString,
        Int32 nMaxCount
    );

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int RegisterWindowMessage(string lpString);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessageTimeout(IntPtr hwnd, IntPtr wParam, IntPtr lParam, IntPtr fuFlags, IntPtr uTimeout, IntPtr lpdwResult);

    [DllImport("ole32.dll", CharSet = CharSet.Auto)]
    public static extern Guid IIDFromString(string lpsz);

  }
}