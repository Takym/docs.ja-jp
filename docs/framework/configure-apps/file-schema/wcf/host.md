---
title: '&lt;ホスト&gt;'
ms.date: 03/30/2017
ms.assetid: be566d55-9d50-4b2e-985d-52a5cc26cbbb
ms.openlocfilehash: afa9d65223ab3a7730a55bc41ed98458707b32db
ms.sourcegitcommit: 4ac80713f6faa220e5a119d5165308a58f7ccdc8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/09/2019
ms.locfileid: "54145229"
---
# <a name="lthostgt"></a>&lt;ホスト&gt;
サービス ホストの設定を指定します。  
  
 \<system.ServiceModel >  
\<services>  
\<サービス >  
\<ホスト >  
  
## <a name="syntax"></a>構文  
  
```xml  
<host>
  <baseAddresses>
    <add baseAddress="string" />
  </baseAddresses>
  <timeOuts closeTimeout="TimeSpan"
            openTimeout="TimeSpan" />
</host>
```  
  
## <a name="type"></a>型  
 `Type`  
  
## <a name="attributes-and-elements"></a>属性および要素  
 以降のセクションでは、属性、子要素、および親要素について説明します。  
  
### <a name="attributes"></a>属性  
 なし。  
  
### <a name="child-elements"></a>子要素  
  
|要素|説明|  
|-------------|-----------------|  
|[\<baseAddresses >](../../../../../docs/framework/configure-apps/file-schema/wcf/baseaddresses.md)|サービス ホストによって使用されるベース アドレスを指定する `baseAddress` 要素のコレクション。|  
|[\<タイムアウト >](../../../../../docs/framework/configure-apps/file-schema/wcf/timeouts.md)|サービス ホストを開くまたは閉じるまでに待機できる期間を指定する構成要素。|  
  
### <a name="parent-elements"></a>親要素  
  
|要素|説明|  
|-------------|-----------------|  
|[\<service>](../../../../../docs/framework/configure-apps/file-schema/wcf/service.md)|Windows Communication Foundation (WCF) サービスの設定を指定します。|  
  
## <a name="see-also"></a>関連項目  
 <xref:System.ServiceModel.Configuration.HostElement>  
 <xref:System.ServiceModel.ServiceHost>  
 [ホスティング](../../../../../docs/framework/wcf/feature-details/hosting.md)
