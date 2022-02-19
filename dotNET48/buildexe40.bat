SET CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
%CSC% /target:library /out:./dll/FileSys.dll "FileSys.cs"
%CSC% /out:"main.exe" SystemWatch.cs main.cs
main.exe "C:\Program Files (x86)\UWSC\UWSC.exe" "UWSC"
pause