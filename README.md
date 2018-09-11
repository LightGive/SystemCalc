# SystemCalc　[![License](https://img.shields.io/badge/license-MIT-lightgrey.svg?style=flat)](http://mit-license.org)<br>
Unityで物理・図形・その他の計算など、頻繁に使用する関数をまとめたスクリプト<br>
物理計算は質量、空気抵抗、マグヌス効果などを含まない簡単な計算です。<br>
関数には複数のオーバーロードを追加してあります。<br>

## Update
(v1.0.1)二点の座標の位置から二次関数の式を求める関数を追加(2018.09.11)

## Download (UnityPackage)
[SystemCalc(1.0.0)_IncludedExample](https://www.dropbox.com/s/vjln000eo9g17fc/SystemCalc%281.0.0%29_IncludedExample.unitypackage?dl=0"SystemCalc(1.0.0)_IncludedExample")<br>
[SystemCalc(1.0.0)_NoExample](https://www.dropbox.com/s/1p4fpj0jhnm8hd7/SystemCalc%281.0.0%29_NoExample.unitypackage?dl=0"SystemCalc(1.0.0)_NoExample")<br>

## List of Functions<br>
* GetCircleLineIntersection (円と線の交点を求める)<br>
* GetIntersectionOfCircleAndCircle (円と円の交点を求める)<br>
* GetLineNearPoint (二点間の線上で一番近い座標を求める)<br>
* GetVelocityTopTime (初速を加えた時、何秒後に頂点に達するかを求める)<br>
* GetVelocityTopHeight (初速を加えた時の最高地点の高さを求める)<br>
* GetVelocityTopPos (初速を加えた時の最高地点の座標を求める)<br>
* GetArrayMax (配列内の一番大きい値を返す)<br>
* GetArrayMin (配列内の一番小さい値を返す)<br>
* GetArraySum (配列内の値を足して返す)<br>

## Example
代表的な関数の例を一部挙げます。<br>
使い方などでわからない部分や、追加してほしい関数等があれば、TwitterのDMで伝えて下さい。<br>

### ・GetCircleLineIntersection
円と線分との交点を取得します。<br>
直線ではなく、始点と終点を含む線分との交差を判定する。<br>
<img src="https://78.media.tumblr.com/37909122011ba993119e3f94faa2841a/tumblr_pb88a5YaNJ1u4382eo1_400.gif" alt="サンプル1" title="サンプル"><br>

```
public static bool GetIntersectionOfLineAndCircle(
  Vector2 _linePoint1, 
  Vector2 _linePoint2, 
  Vector2 _circleCenter, 
  float _circleRadius, 
  out Vector2 _intersectionPoint1, 
  out Vector2 _intersectionPoint2)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _linePoint1        |(Vector2)線分の始点|
| _linePoint2        |(Vector2)線分の終点|
| _circleCenter      |(Vector2)円の中心点|
| _circleRadius      |(float)円の半径|
| _intersectionPoint1|(out Vector2)円と線分が交差していた場合、交差している座標が入る|
| _intersectionPoint2|(out Vector2)円と線分が交差していた場合、交差している座標が入る|

#### 返り値 <br>
(bool)線と円が一点以上交差しているかどうか<br>
<br>
### ・GetIntersectionOfCircleAndCircle<br>
円と円が交差しているかの判定と、交差している点の座標を求める<br>
<img src="https://78.media.tumblr.com/807b8b1c3709ad917cea8d7abe48d046/tumblr_pb8hpqvu6Y1u4382eo1_400.gif" alt="サンプル2" title="サンプル"><br>
```
public static bool GetIntersectionOfCircleAndCircle(
  Vector2 _circlePoint1, 
  float _circleRadius1, 
  Vector2 _circlePoint2, 
  float _circleRadius2, 
  out Vector2 _intersectionPoint1, 
  out Vector2 _intersectionPoint2)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _circlePoint1      |(Vector2)円Bの中心の座標|
| _circleRadius1     |(float)円Aの半径|
| _circlePoint2      |(Vector2)円Bの中心の座標|
| _circleRadius2     |(float)円Bの半径|
| _intersectionPoint1|(out Vector2)円Aと円Bが交差していた場合、交差している座標が入る。交差していない時は newVector2(0.0f,0.0f)が入る|
| _intersectionPoint2|(out Vector2)円Aと円Bが交差していた場合、交差している座標が入る。交差していない時は newVector2(0.0f,0.0f)が入る|

#### 返り値 <br>
(bool)円と円が交差しているかどうか<br>
<br>
### ・GetLineNearPoint<br>
指定した座標で、線上の一番近い座標を返す<br>
また、AからBを0-1と置いた場合の値も取得できる<br>
<img src="https://78.media.tumblr.com/3fc64a053bdd6856c4c8fe1cb9665ab4/tumblr_pb8jj0nHTw1u4382eo1_400.gif" alt="サンプル3" title="サンプル"><br>
```
public static Vector3 GetLineNearPoint(
  Vector3 _linePoint1, 
  Vector3 _linePoint2, 
  Vector3 _checkPoint, 
  bool _isLimit, 
  out float _lerp)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _linePoint1|(Vector2)線分の始点|
| _linePoint2|(Vector2)線分の終点|
| _checkPoint|(Vector2)確認したい座標|
| _isLimit   |(bool)線上の始点から終点で制限をかけるかどうか。|
| _lerp      |(out float)始点を0、終点を1とした時の値。|

#### 返り値 <br>
(Vector3)線状で一番近い座標<br>
<br>

[](---------------------------区切り---------------------------)

### ・GetVelocityTopTime
球に初速を加えた時、頂点に達するまでの時間を求める<br>
```
public static float GetVelocityTopTime(
  Vector3 _vec, 
  Vector3 _gravity)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _vec    |(Vector3)球の初速|
| _gravity|(Vector3)重力加速度|

#### 返り値 <br>
(float)頂点に到達する時間(秒)<br>
<br>

[](---------------------------区切り---------------------------)

### ・GetVelocityTopTime
球に初速を加えた時、最高地点の高さを求める<br>
```
public static float GetVelocityTopHeight(
  Vector3 _vec, 
  float _startHeight, 
  Vector3 _gravity)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _vec        |(Vector3)球の初速|
| _startHeight|(float)球の初速|
| _gravity    |(Vector3)重力加速度|

#### 返り値 <br>
(float)頂点に到達する高さ<br>
<br>


[](---------------------------区切り---------------------------)

### ・GetBallisticpredictionPoint
初速を加えた後の弾道予測点を求める<br>
<img src="https://78.media.tumblr.com/0fd8b72912fb1c8bba820c12ca2bdbb5/tumblr_pbfuimltvo1u4382eo1_400.gif" alt="サンプル1" title="サンプル"><br>
```
public static Vector3[] GetBallisticpredictionPoint(
  Vector3 _vec,
  Vector3 _startPos, 
  int _pointNum, 
  float _intervalTime, 
  Vector3 _gravity)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _vec        　　|(Vector3)球の初速|
| _startPos   　　|(Vector3)初速を加えた時の座標|
| _pointNum   　　|(int)取得する座標の数|
| _intervalTime|(Vector3)取得する座標の間隔の時間(秒)|
| _gravity     |(Vector3)重力加速度|

#### 返り値 <br>
(Vector3[])弾道予測線の座標<br>
<br>


### ・VectorToAngle
ベクトルから角度に変関する<br>
<img src="https://78.media.tumblr.com/c5feb697b32ddf82ae6df3db5f46d1a1/tumblr_pbgwgyzhqq1u4382eo1_400.gif" alt="サンプル1" title="サンプル"><br>
```
public static float VectorToAngle(
  Vector2 _vec)
```
#### パラメーター<br>
|引数| 説明|
|:-----------|:-----------|
| _vec       |(Vector2)角度に変更するベクトル|

#### 返り値 <br>
(float)角度<br>
<br>


## Future<br>
* 初速を加えた時、何秒後に地面に落ちるか<br>
* 球と線との交点を求める<br>
* 角度→ベクトル<br>
* 行列を渡してグリッドの座標を返す<br>
* ベジュ曲線を求める<br>
* 基準点と視野角と相手の座標を渡して視界内にあるか<br>

## License<br>
See [LICENSE](/LICENSE.md).


