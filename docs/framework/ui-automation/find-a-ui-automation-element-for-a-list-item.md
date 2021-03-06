---
title: リスト項目の UI オートメーション要素の検索
ms.date: 03/30/2017
dev_langs:
- csharp
- vb
helpviewer_keywords:
- list items, finding elements for
- elements, finding for list items
- UI Automation, finding elements for List items
ms.assetid: c326ad2b-2144-4f64-ae4c-d850c74f95c5
author: Xansky
ms.author: mhopkins
ms.openlocfilehash: 4e8822ce8d33d285475be5ec85d36c5085d46f4b
ms.sourcegitcommit: fb78d8abbdb87144a3872cf154930157090dd933
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "47198242"
---
# <a name="find-a-ui-automation-element-for-a-list-item"></a>リスト項目の UI オートメーション要素の検索
> [!NOTE]
>  このドキュメントは、[!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] 名前空間で定義されているマネージド <xref:System.Windows.Automation> クラスを使用する .NET Framework 開発者を対象としています。 [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)]に関する最新情報については[Windows Automation API: UI Automation](https://go.microsoft.com/fwlink/?LinkID=156746)をご覧ください。  
  
 このトピックでは、取得する方法を示します、<xref:System.Windows.Automation.AutomationElement>項目のインデックスがわかっている場合、リスト内の項目にします。  
  
## <a name="example"></a>例  
 次の例では、2 つの方法を使用して、一覧から、指定した項目を取得する<xref:System.Windows.Automation.TreeWalker>とその他の using<xref:System.Windows.Automation.AutomationElement.FindAll%2A>します。  
  
 最初の手法の高速化する傾向にあります[!INCLUDE[TLA2#tla_win32](../../../includes/tla2sharptla-win32-md.md)]コントロールではなく、2 つ目は、Windows Presentation Foundation (WPF) コントロールの高速です。  
  
 [!code-csharp[UIAClient_snip#184](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClient_snip/CSharp/ClientForm.cs#184)]
 [!code-vb[UIAClient_snip#184](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClient_snip/VisualBasic/ClientForm.vb#184)]  
  
## <a name="see-also"></a>関連項目  
 [UI オートメーション要素の取得](../../../docs/framework/ui-automation/obtaining-ui-automation-elements.md)
