---
title: unsafe キーワード - C# リファレンス
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords:
- unsafe_CSharpKeyword
- unsafe
helpviewer_keywords:
- unsafe keyword [C#]
ms.assetid: 7e818009-1c6e-4b9e-b769-3728a01586a0
ms.openlocfilehash: 81a293a6922a71f7428167c50aed064d7387a099
ms.sourcegitcommit: bdd930b5df20a45c29483d905526a2a3e4d17c5b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "53236623"
---
# <a name="unsafe-c-reference"></a>unsafe (C# リファレンス)

`unsafe` キーワードは、ポインターに関連するすべての操作に必要な、unsafe コンテキストを示します。 詳しくは、「[アンセーフ コードとポインター](../../programming-guide/unsafe-code-pointers/index.md)」をご覧ください。

`unsafe` 修飾子は、型またはメンバーの宣言で使用できます。 そのため、型やメンバーの全体的なテキスト範囲が unsafe コンテキストと見なされます。 たとえば、次に示すのは、`unsafe` 修飾子を使用して宣言されたメソッドです。

```csharp
unsafe static void FastCopy(byte[] src, byte[] dst, int count)
{
    // Unsafe context: can use pointers here.
}
```

unsafe コンテキストのスコープはパラメーター リストからメソッドの末尾までなので、ポインターはパラメーター リストでも使用できます。

```csharp
unsafe static void FastCopy ( byte* ps, byte* pd, int count ) {...}
```

また、unsafe ブロックを使用して、そのブロック内で unsafe コードを使用できるようにすることもできます。 次に例を示します。

```csharp
unsafe
{
    // Unsafe context: can use pointers here.
}
```

unsafe コードをコンパイルするには、 [/unsafe](../compiler-options/unsafe-compiler-option.md) コンパイラ オプションを指定する必要があります。 unsafe コードは、共通言語ランタイムでは検証できません。

## <a name="example"></a>例

[!code-csharp[csrefKeywordsModifiers#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#22)]

## <a name="c-language-specification"></a>C# 言語仕様

詳細については、「[C# 言語の仕様](../language-specification/index.md)」の[アンセーフ コード](~/_csharplang/spec/unsafe-code.md)に関するセクションを参照してください。 言語仕様は、C# の構文と使用法に関する信頼性のある情報源です。

## <a name="see-also"></a>関連項目

- [C# リファレンス](../index.md)
- [C# プログラミング ガイド](../../programming-guide/index.md)
- [C# のキーワード](index.md)
- [fixed ステートメント](fixed-statement.md)
- [アンセーフ コードとポインター](../../programming-guide/unsafe-code-pointers/index.md)
- [固定サイズ バッファー](../../programming-guide/unsafe-code-pointers/fixed-size-buffers.md)