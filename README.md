# SystemCalc<br>
Unityで物理・図形・その他の計算など、頻繁に使用する関数をまとめたスクリプト<br>
物理計算は質量、空気抵抗、マグヌス効果などを含まない簡単な計算です。<br>
関数には複数のオーバーロードを追加してあります。<br>

## List of Functions<br>
* GetCircleLineIntersection (円と線の交点を求める)<br>
* GetIntersectionOfCircleAndCircle (円と円の交点を求める)<br>
* GetLineNearPoint (二点間の線上で一番近い座標を求める)<br>
* GetVelocityTopTime (初速を加えた時、何秒後に頂点に達するかを求める)<br>
* GetVelocityTopHeight (初速を加えた時の最高地点の高さを求める)<br>
* GetVelocityTopPos (初速を加えた時の最高地点の座標を求める)<br>
* GetArrayMax (配列内の一番大きい値を返す)<br>
* GetArrayMin (配列内の一番小さい値を返す)<br>


## Example
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

## Future<br>
* 初速を加えた時、何秒後に地面に落ちるか<br>
* 球と線との交点を求める<br>
* 線と線との最も近い位置を求める<br>
* 面の表か裏か判定をする<br>
* AからBに向く角度を求める<br>
* ベクトル→角度<br>
* 角度→ベクトル<br>
* 配列内の一番大きい値の添え字を返す<br>
* 最小値と最大値の間に制限<br>
* 行列を渡してグリッドの座標を返す<br>
* 大きさと頂点数を渡して、～角形の座標を求める<br>
* ベジュ曲線を求める<br>
* 基準点と視野角と相手の座標を渡して視界内にあるか<br>

## License<br>
See [LICENSE](/LICENSE.md).


