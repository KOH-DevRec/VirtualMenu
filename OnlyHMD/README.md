# VirtualMenu(OnlyHMD)
## 概要
本ディレクトリに存在するUnityプロジェクトは、ハンドジェスチャーによるメニュー操作と  
同時並行で異なるタスクを実施した際のパフォーマンスを比較検証することを目的として作成しています。  
（XRのGUIメニューって他の作業をしている時も上手く操作できるの？っていう検証実験をしました。）  
各メニューの操作方法および並行タスクの内容については別項「操作方法」「タスク内容」をご確認ください。  

利用する際はUnityの設定でVR開発が可能な状態にしてください。  

### 開発・動作環境
- Unity2020.3.21
- 利用デバイス：Oculus Quest2

## 操作方法
Unityプロジェクト内のオブジェクト「HUD」内には以下5種のGUIメニューが存在します。  
<img width="200" alt="directionPhoto0" src="https://github.com/user-attachments/assets/41fa816d-c315-40be-9435-265b4eb30a8d" />
<img width="200" alt="comparison1" src="https://github.com/user-attachments/assets/4290207b-b5fe-4261-9dda-08fd6c6a5e77" />
<img width="200" alt="comparison2" src="https://github.com/user-attachments/assets/e611e3e8-bc54-4848-a6e7-28c7d41a87a7" />
<img width="200" alt="comparison3" src="https://github.com/user-attachments/assets/aa0c3fdd-887e-4c81-aca5-0943a0ed74ad" />
- Direction
- MenuCanvas-VLine
- MenuCanvas-BVLine
- MenuCanvas-HLine
- MenuCanvas-AllSides

各メニューはオブジェクトを有効化することで利用できます。  
HUD内で有効化するメニューは一つのみを想定しています。  
「MenuCanves-****」はオブジェクト毎に表示位置が異なりますが、同じジェスチャーで操作可能です。  

### Direction
操作には左手のみを利用し、メニューは人差し指と親指を開くことによって表示されます。  
項目の選択時には、人差し指の方向を変えることで項目を変更し、  
親指を一度だけ閉じるジェスチャ操作で項目を決定することができます。  
親指を閉じ続けるとその項目を連打（選択し続ける）判定となるため、選択する際には素早く開閉してください。  
メニューは人差し指と親指を閉じることによって非表示にすることが可能です。  

### MenuCanves
メニューは常に画面に表示されており、操作には左手のみを利用します。  
左手の親指と他の指を合わせることで項目選択を行います。  
例）親指+人差し指で項目Aを選択  
選択後は指を開いた状態に戻してください。  
※入力を正しく読み取る為に、非選択時は左手を開いた状態にしてください。


## タスク内容
並行タスクは「オブジェクト認識」「突発的な操作」の2種類存在します。  
Scriptディレクトリ内の「CameraMoveManager.cs」から入力を読み取り、  
どちらのタスクを実施するか決定しています。  
内容については以下の通りです。

### タスク1:オブジェクト認識
指定されたオブジェクトがXR空間内にいくつ存在するか探すタスクです。 
<img width="600" alt="taskPhoto1" src="https://github.com/user-attachments/assets/db2c8a4f-080b-41a2-9604-a4a73a22511b" />  

視点は一定時間回転し、初期位置に戻った際に回答を行います。  
検証時にはメニュー操作も同時に行うように実装されています。  

### タスク2:突発的な操作
複数ディスプレイの表示が変化した際に表示に合ったボタンを押すタスクです。  
<img width="600" alt="taskPhoto2" src="https://github.com/user-attachments/assets/3a6ffc33-fcda-4a62-ae93-88d166e10152" />  

ディスプレイに映し出された色とボタンの色が対応しています。  
タスク1同様、検証時にはメニュー操作も同時に行うように実装されています。  
