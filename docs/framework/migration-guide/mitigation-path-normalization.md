---
title: '軽減策: パスの正規化'
ms.date: 03/30/2017
ms.assetid: 158d47b1-ba6d-4fa6-8963-a012666bdc31
author: rpetrusha
ms.author: ronpet
ms.openlocfilehash: aa31641cc325f15b9afe677038deb33c57e77fd1
ms.sourcegitcommit: 2eceb05f1a5bb261291a1f6a91c5153727ac1c19
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/04/2018
ms.locfileid: "43508814"
---
# <a name="mitigation-path-normalization"></a>軽減策: パスの正規化
[!INCLUDE[net_v462](../../../includes/net-v462-md.md)] を対象とするアプリ以降では、.NET Framework のパスの正規化が変更されました。  
  
## <a name="what-is-path-normalization"></a>パスの正規化とは  
 パスの正規化では、パスまたはファイルを識別する文字列を変更し、対象のオペレーティング システムの有効なパスに準拠するようにします。 通常、正規化では次のことを行います。  
  
-   コンポーネントとディレクトリの区切り記号を正規化する。  
  
-   現在のディレクトリを相対パスに適用する。  
  
-   パスの相対ディレクトリ (`.`) または親ディレクトリ (`..`) を評価する。  
  
-   指定した文字をトリミングする。  
  
## <a name="the-changes"></a>変更点  
 [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] を対象とするアプリ以降では、次のようにパスの正規化が変更されました。  
  
-   ランタイムはオペレーティング システムの [GetFullPathName](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea) 関数に従って、パスを正規化します。  
  
-   正規化では、ディレクトリ セグメントの末尾 (ディレクトリ名の末尾のスペースなど) がトリミングされなくなりました。  
  
-   `\\.\` や `\\?\` (mscorlib.dll のファイル I/O API の場合) を含む、完全に信頼できるデバイス パス構文がサポートされます。  
  
-   ランタイムではデバイス構文パスは検証されません。  
  
-   代替データ ストリームにアクセスするためのデバイス構文の使用はサポートされています。  
  
## <a name="impact"></a>影響  
 [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] 以降を対象とするアプリでは、これらの変更は既定で有効になります。 パフォーマンスが向上すると同時に、以前はアクセス不可だったパスにメソッドでアクセスできるようになります。  
  
 [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] 以前のバージョンを対象とするアプリが [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] 以降で実行される場合、この変更の影響は受けません。  
  
## <a name="mitigation"></a>軽減策  
 [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] 以降を対象とするアプリでこの変更を無効にし、従来の正規化を使用することができます。その場合、アプリケーション構成ファイルの [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) セクションに次の行を追加します。  
  
```xml  
<runtime>  
    <AppContextSwitchOverrides value="Switch.System.IO.UseLegacyPathHandling=true" />    
</runtime>  
```  
  
 [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] 以前を対象とするものの、[!INCLUDE[net_v462](../../../includes/net-v462-md.md)] 以降で実行されているアプリは、パスの正規化の変更を有効にすることができます。その場合、アプリケーション構成ファイルの [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) セクションに次の行を追加します。  
  
```xml  
<runtime>  
    <AppContextSwitchOverrides value="Switch.System.IO.UseLegacyPathHandling=false" />    
</runtime>  
```  
  
## <a name="see-also"></a>参照  
 [変更の再ターゲット](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-6-2.md)
