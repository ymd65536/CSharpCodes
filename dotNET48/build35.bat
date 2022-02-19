SET CSC="C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe"
%CSC% /target:library /out:./dll/FileSys.dll "FileSys.cs"
%CSC% /target:library /out:./dll/SystemWatch.dll "SystemWatch.cs"
%CSC% /out:"main.exe" SystemWatch.cs "main.cs"
pause