# VirtualMenu(HMD+LeapMotion)

## 前書き
<img height="210" alt="directionPhoto1" src="https://github.com/user-attachments/assets/895c3370-8565-45d6-9a8b-6d0cccf834eb" />
<img height="210" alt="directionPhoto3 - コピー" src="https://github.com/user-attachments/assets/f89bea69-ece2-44a0-9f86-e524a22cca6a" />

本リポジトリはXR環境でのGUIメニュー「DirectionMenu(OneHand4Menu)」  
および他メニューとの比較を目的として作成されたものです。  
実装されているメニューはハンドジェスチャーでの操作を想定されており、  
以下2通りの動作環境を想定しディレクトリを分けています。
- HMD(:Head Mounted Display)+LeapMotionを利用した場合
- ハンドトラッキング可能なHMDのみを利用した場合

UnityでのVR開発経験があることを前提として書いている部分があるため、  
一度VRアプリケーションやUnityでの開発に触れておくことを推奨します。  

以上のことに留意して、本アプリケーションを利用してください。  

## 緊急時の復旧方法

前提条件として、Unityエディタが停止するなどの不具合が生じた場合、  
その後絶対にプロジェクトをそのまま再度開かないでください。  
一度でも立ち上げた場合、この方法で復旧することは不可能です。  
復旧後は、最後に保存した状態もしくは最後にUnityプロジェクトを再生した状態に復旧できます。  

Unityエディタ内でクラッシュや無限ループが起こった場合、以下の通りに復旧してください。多分復旧できます。  

1．Unityプロジェクトのフォルダへ移動  
2．Temp/__Backupscenesフォルダを検索し、該当フォルダをコピー   
3．該当フォルダをTempフォルダ以外へ退避（ペースト）  
4．ここでUnityエディタを起動し、最後に開いていたシーンを同じように開く  
5．ゲームを再生  
6．再生中に__Backupscenesフォルダを元の場所に上書きする  
7．再生を停止  

以上の手順で復旧が可能ですが、バージョンによって復旧できない可能性があるため、こまめに保存することを心掛けてください。  
