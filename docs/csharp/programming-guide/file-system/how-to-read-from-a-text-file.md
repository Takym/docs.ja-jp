---
title: '方法: テキスト ファイルから読み込む - C# プログラミング ガイド'
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords:
- StreamReader.ReadToEnd
helpviewer_keywords:
- text files, writing to
- reading text files
- reading data, text files
- text files, reading
ms.assetid: 92246c5b-e819-4eea-9370-1a9460e12de3
ms.openlocfilehash: 67e98750af589a3deb5e9d0d51f8b1204fdaad84
ms.sourcegitcommit: bdd930b5df20a45c29483d905526a2a3e4d17c5b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "53240308"
---
# <a name="how-to-read-from-a-text-file-c-programming-guide"></a>方法: テキスト ファイルから読み込む (C# プログラミング ガイド)
この例では、<xref:System.IO.File?displayProperty=nameWithType> クラスの静的メソッド <xref:System.IO.File.ReadAllText%2A> と <xref:System.IO.File.ReadAllLines%2A> を使用してテキスト ファイルの内容を読み取ります。  
  
 <xref:System.IO.StreamReader> の使用例については、「[方法: テキスト ファイルを一度に 1 行読み込む](../../../csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time.md)」をご覧ください。  
  
> [!NOTE]
>  この例で使用されるファイルは、「[方法: テキスト ファイルに書き込む](../../../csharp/programming-guide/file-system/how-to-write-to-a-text-file.md)」のトピックで作成されます。  
  
## <a name="example"></a>例  
 [!code-csharp[csFilesandFolders#4](../../../csharp/programming-guide/file-system/codesnippet/CSharp/how-to-read-from-a-text-file_1.cs)]  
  
## <a name="compiling-the-code"></a>コードのコンパイル  
 コードをコピーし、C# のコンソール アプリケーションに貼り付けます。  
  
 「[方法: テキスト ファイルに書き込む](../../../csharp/programming-guide/file-system/how-to-write-to-a-text-file.md)」のテキスト ファイルを使わない場合は、`ReadAllText` と `ReadAllLines` の引数を、ご使用のコンピューター上適切なパスおよびファイル名に置き換えます。  
  
## <a name="robust-programming"></a>信頼性の高いプログラミング  
 次の条件を満たす場合は、例外が発生する可能性があります。  
  
-   ファイルが存在しない、または指定した場所に存在しない。 ファイル名のパスとスペルを確認してください。  
  
## <a name="net-framework-security"></a>.NET Framework セキュリティ  
 ファイル名に基づいてファイルの内容を判断しないでください。 たとえば、`myFile.cs` というファイルが C# のソース ファイルではない可能性もあります。  
  
## <a name="see-also"></a>参照

- <xref:System.IO?displayProperty=nameWithType>  
- [C# プログラミング ガイド](../../../csharp/programming-guide/index.md)  
- [ファイル システムとレジストリ (C# プログラミング ガイド)](../../../csharp/programming-guide/file-system/index.md)
