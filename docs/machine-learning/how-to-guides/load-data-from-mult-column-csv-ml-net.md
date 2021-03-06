---
title: 機械学習の処理のために多数の列を含むデータを CSV ファイルから読み込む - ML.NET
description: ML.NET で機械学習モデルの構築、トレーニング、スコア付けに使用するために、CSV ファイルから多数の列を含むデータを読み込む方法について説明します
ms.date: 11/07/2018
ms.custom: mvc,how-to
ms.openlocfilehash: 3b87231f8e5a4ce39761d1ec71398b5295666d07
ms.sourcegitcommit: ccd8c36b0d74d99291d41aceb14cf98d74dc9d2b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "53156550"
---
# <a name="load-data-with-many-columns-from-a-csv-file-for-machine-learning-processing---mlnet"></a>機械学習の処理のために多数の列を含むデータを CSV ファイルから読み込む - ML.NET

`TextLoader` を使用して、テキスト ファイルからデータを読み込みます。 データの列、型、およびテキスト ファイル内での位置を指定する必要があります。

入力ファイルに同じ型の列が多数含まれ、常に一緒に使用される場合は、それらを*ベクター列*として読み込みます。 次の例に示すように、この方法ではデータ スキーマが簡潔になり、不必要なパフォーマンス コストを回避できます。

[ファイルの例](https://github.com/dotnet/machinelearning/tree/master/test/data/generated_regression_dataset.csv):

```console
-2.75,0.77,-0.61,0.14,1.39,0.38,-0.53,-0.50,-2.13,-0.39,0.46,140.66
-0.61,-0.37,-0.12,0.55,-1.00,0.84,-0.02,1.30,-0.24,-0.50,-2.12,148.12
-0.85,-0.91,1.81,0.02,-0.78,-1.41,-1.09,-0.65,0.90,-0.37,-0.22,402.20
0.28,1.05,-0.24,0.30,-0.99,0.19,0.32,-0.95,-1.19,-0.63,0.75,443.51
```

`TextLoader` を使用したこのファイルの読み取り:

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Create the reader: define the data columns and where to find them in the text file.
var reader = mlContext.Data.TextReader(new[] {
        // We read the first 10 values as a single float vector.
        new TextLoader.Column("FeatureVector", DataKind.R4, 0, 9),
        // Separately, read the target variable.
        new TextLoader.Column("Target", DataKind.R4, 10)
    },
    // Default separator is tab, but we need a comma.
    Separator = ",");

// Now read the file (remember though, readers are lazy, so the actual reading will happen when the data is accessed).
var data = reader.Read(dataPath);
```