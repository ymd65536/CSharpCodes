# �ե�����Υץ�ѥƥ�����С�������������

## AppVersionCheck���饹

### AppVersionCheck�᥽�å�

�᥽�åɥ����ס���Ū�᥽�å�

��������������ե����̾,�С�������Ĵ�٤����ե�����̾

## ��ư����

### launch.json

```json

{
    // IntelliSense ����Ѥ������Ѳ�ǽ��°����ؤ٤ޤ���
    // ��¸��°����������ۥС�����ɽ�����ޤ���
    // �ܺپ���ϼ����ǧ���Ƥ�������: https://go.microsoft.com/fwlink/?linkid=830387
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/bin/Debug/net5.0/FileSearch.dll",
            "args": [
                "C:\\Program Files (x86)\\Microsoft\\Edge\\Application",
                "msedge.exe"
            ],
            "cwd": "${workspaceFolder}",
            "console": "internalConsole",
            "stopAtEntry": false
        },
        {
            "name": ".NET Core Attach",
            "type": "coreclr",
            "request": "attach"
        }
    ]
}

```

### task.json

```json

{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/FileSearch.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "publish",
            "command": "dotnet",
            "type": "process",
            "args": [
                "publish",
                "${workspaceFolder}/FileSearch.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "watch",
            "command": "dotnet",
            "type": "process",
            "args": [
                "watch",
                "run",
                "${workspaceFolder}/FileSearch.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
}

```