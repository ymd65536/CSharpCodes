# プロキシを経由してファイルをダウンロードするサンプル

## プロキシの設定

プロキシの設定はjsonで管理

Mainの引数 `args`には設定ファイルのパスと文字エンコードを渡す。

```json
{
  "UserName":"UserId",
  "PassWord":"password",
  "ProxyName":"ProxyURL:PortNum",
  "RequestUrl":"https://msedgedriver.azureedge.net/94.0.992.38/edgedriver_win32.zip"
}
```
