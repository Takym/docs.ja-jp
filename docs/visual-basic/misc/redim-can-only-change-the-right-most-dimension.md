---
title: "'ReDim' では最も右にある次元のみ変更できます"
ms.date: 07/20/2015
f1_keywords:
- vbrArray_TypeMismatch
ms.assetid: d53cf41b-7a7a-466c-a29a-920d99698fa9
ms.openlocfilehash: 5b4f054c5d1dfad52ce19e1a9f9d246945866703
ms.sourcegitcommit: 0888d7b24f475c346a3f444de8d83ec1ca7cd234
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/22/2018
ms.locfileid: "53767396"
---
# <a name="redim-can-only-change-the-right-most-dimension"></a>'ReDim' では最も右にある次元のみ変更できます
`ReDim` ステートメントが `Preserve` キーワードを使用して、最後のディメンションではない配列のディメンションを変更しようとしました。 `Preserve`を使用すると、配列の最後のディメンションについてのみ、サイズを変更できます。 他のすべてのディメンションに対しては、既存の配列と同じサイズを指定する必要があります。  
  
## <a name="to-correct-this-error"></a>このエラーを解決するには  
  
-   `Preserve` キーワードを削除します。  
  
## <a name="see-also"></a>関連項目  
 [Visual Basic における配列](~/docs/visual-basic/programming-guide/language-features/arrays/index.md)  
 [Visual Basic で配列の次元](~/docs/visual-basic/programming-guide/language-features/arrays/array-dimensions.md)  
 [ReDim ステートメント](../../visual-basic/language-reference/statements/redim-statement.md)  
 [Dim ステートメント](../../visual-basic/language-reference/statements/dim-statement.md)  
 [保存 - 削除](https://msdn.microsoft.com/library/91badeab-b4e0-48b6-92c9-9f0c8f995d81)
