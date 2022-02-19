# CSV から指定の列だけ取り出したい

## これはどんなプログラム

A 列、B 列、C 列、D 列と 4 つ列があったときに ABC だけ取り出したい場合は
以下のような JSON を書いてプログラムを実行すると
指定した列だけ取り出すことができます。

```json
{
  "column_names": [
    { "num": 0, "name": "A" },
    { "num": 1, "name": "B" },
    { "num": 2, "name": "C" }
  ]
}
```

## 注意点

取り出す列を指定するときは列が順番どおりに並んでいる必要があります。
また、ダブルクウォートで括られている必要があります。

例）以下の CSV から A 列 B 列 D 列を取り出す場合はこのプログラムで対応できません。

```csv
"A","B","C","D"
"1","2","3","4"
```

## 実現方法概略

名前空間は以下を参照

```cs
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;
```

変換対象の CSV には`TextFieldParser` を利用しています。
