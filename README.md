# Gemini
.NETでオブジェクトの深いコピーを作成するためのライブラリです。

## 使い方
拡張メソッド `DeepClone()` で完結します。

言語仕様上、`object`を返します。必要に応じて目的の型にキャストしてください。

```cs
using Boronology.Gemini;

//クローンしたいオブジェクト
Something obj = new Something();

//クローン（object型）
object cloned = obj.DeepClone();

//必要に応じてキャスト
Something clonedSomething = (Something)cloned;
```

## 制限
`Delegate`を継承する関数オブジェクトは`Delegate.Clone()`を使用しているため浅いコピーです。