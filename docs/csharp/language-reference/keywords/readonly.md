---
title: readonly キーワード - C# リファレンス
ms.custom: seodec18
ms.date: 06/21/2018
f1_keywords:
- readonly_CSharpKeyword
- readonly
helpviewer_keywords:
- readonly keyword [C#]
ms.assetid: 2f8081f6-0de2-4903-898d-99696c48d2f4
ms.openlocfilehash: dfbeb5ff94f39e8d8df03feea9ff55db748d2182
ms.sourcegitcommit: deb9225a55485a5a6e6c7914deb30ccfceb69d3f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/05/2019
ms.locfileid: "54058582"
---
# <a name="readonly-c-reference"></a>readonly (C# リファレンス)

`readonly` キーワードは、3 つのコンテキストで使用できる修飾子です。

- [フィールドの宣言](#readonly-field-example)では、`readonly` は、フィールドへの割り当てが、宣言の一部として、または同じクラスのコンストラクター内でのみ可能であることを示します。
- [`readonly struct` の定義](#readonly-struct-example)では、`readonly` は `struct` が変更不可であることを示します。
- [`ref readonly` メソッドの戻り値](#ref-readonly-return-example)では、`readonly` 修飾子は、メソッドが参照を返し、その参照への書き込みが許可されないことを示します。

最後の 2 つのコンテキストは、C# 7.2 で追加されました。

## <a name="readonly-field-example"></a>読み取り専用フィールドの例

この例では、`year` フィールドの値は、クラス コンストラクターで値が割り当てられていても `ChangeYear` メソッドでは変更できません。

[!code-csharp[Readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyField)]

`readonly` のフィールドに値を割り当てることができるのは、次のコンテキスト内に限られます。

- 値が宣言で初期化される場合。次に例を示します。

```csharp
public readonly int y = 5;
```

- インスタンス フィールド宣言を含むクラスのインスタンス コンストラクター内。
- 静的フィールド宣言を含むクラスの静的コンストラクター内。

また、これらのコンストラクター コンテキスト内でのみ、`readonly` フィールドを [out](out-parameter-modifier.md) パラメーターまたは [ref](ref.md) パラメーターとして渡すことができます。

> [!NOTE]
> `readonly` キーワードは [const](const.md) キーワードとは異なります。 `const` フィールドは、フィールドの宣言でしか初期化できません。 `readonly` フィールドは、フィールドの宣言と任意のコンストラクターで複数回割り当てることができます。 このため、`readonly` フィールドは、使用するコンストラクターに応じて異なる値を持つことができます。 また、次の例のように、`const` フィールドがコンパイル時定数であるのに対し、`readonly` フィールドは実行時定数として使用できます。

```csharp
public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;
```

[!code-csharp[Initialize readonly Field example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#InitReadonlyField)]

上の例で、次の例のようなステートメントを使うものとします。

`p2.y = 66;        // Error`

この場合、次のコンパイル エラー メッセージが表示されます。

`A readonly field cannot be assigned to (except in a constructor or a variable initializer)`

## <a name="readonly-struct-example"></a>読み取り専用の構造体の例

`struct` 定義での `readonly` 修飾子は、構造体が**変更不可**であることを宣言します。 次の例のように、`struct` のすべてのインスタンス フィールドを `readonly` とマークする必要があります。

[!code-csharp[readonly struct example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyStruct)]

前の例では、[読み取り専用の自動プロパティ](../../properties.md#read-only)を使ってその記憶域を宣言しています。 これは、これらのプロパティに対して `readonly` バッキング フィールドを作成するようコンパイラに指示します。 `readonly` フィールドを直接宣言することもできます。

```csharp
public readonly struct Point
{
    public readonly double X;
    public readonly double Y;

    public Point(double x, double y) => (X, Y) = (x, y);

    public override string ToString() => $"({X}, {Y})";
}
```

`readonly` に指定されていないフィールドを追加すると、コンパイラ エラー `CS8340`:"読み取り専用の構造体のインスタンス フィールドは、読み取り専用である必要があります" が生成されます。

## <a name="ref-readonly-return-example"></a>ref readonly の戻り値の例

`ref return` での `readonly` 修飾子は、返される参照を変更できないことを示します。 次の例は、origin に参照を返します。 `readonly` 修飾子を使用して、呼び出し元が origin を変更できないことを示しています。

[!code-csharp[readonly struct example](~/samples/snippets/csharp/keywords/ReadonlyKeywordExamples.cs#ReadonlyReturn)]
返される型を `readonly struct` にする必要はありません。 `ref` で返すことができる任意の型を、`ref readonly` で返すことができます。

## <a name="c-language-specification"></a>C# 言語仕様

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## <a name="see-also"></a>関連項目

- [C# リファレンス](../index.md)
- [C# プログラミング ガイド](../../programming-guide/index.md)
- [C# のキーワード](index.md)
- [修飾子](modifiers.md)
- [const](const.md)
- [フィールド](../../programming-guide/classes-and-structs/fields.md)
