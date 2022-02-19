SET CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
%CSC% /target:library /out:./dll/FileSys.dll "FileSys.cs"
%CSC% /target:library /out:./dll/SystemWatch.dll "SystemWatch.cs"
%CSC% /out:"main.exe" SystemWatch.cs "main.cs"
pause