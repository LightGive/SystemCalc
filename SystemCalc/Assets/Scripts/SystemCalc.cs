#region License
//Copyright(c) 2017 Akase Matsuura
//https://github.com/LightGive/SystemCalc

//Permission is hereby granted, free of charge, to any person obtaining a
//copy of this software and associated documentation files (the
//"Software"), to deal in the Software without restriction, including
//without limitation the rights to use, copy, modify, merge, publish, 
//distribute, sublicense, and/or sell copies of the Software, and to
//permit persons to whom the Software is furnished to do so, subject to
//the following conditions:

//The above copyright notice and this permission notice shall be
//included in all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
//EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 様々な計算を扱うクラス
/// </summary>
public static class SystemCalc
{
	/// <summary>
	/// 通常の重力加速度
	/// </summary>
	private const float DefaultGravitationalAcceleration = -9.80665f;
	/// <summary>
	/// 通常の空気抵抗
	/// </summary>
	private const float DefaultDrag = 0.0f;
	/// <summary>
	/// 通常の質量
	/// </summary>
	private const float DefaultMass = 1.0f;
	/// <summary>
	/// ネイピア数,2.718281828...
	/// </summary>
	private const float E = (float)System.Math.E;
	/// <summary>
	/// 通常の重力加速度のベクトル
	/// </summary>
	private static readonly Vector3 DefaultGravitationalAccelerationVec = new Vector3(0.0f, DefaultGravitationalAcceleration, 0.0f);

	#region 使いまわすメンバ変数

	//int
	private static int int_1;
	private static int int_2;
	private static int int_3;
	private static int int_4;
	private static int int_5;
	private static int int_6;
	private static int int_7;
	private static int int_8;
	private static int int_9;
	private static int int_10;

	//float
	private static float float_1;
	private static float float_2;
	private static float float_3;
	private static float float_4;
	private static float float_5;
	private static float float_6;
	private static float float_7;
	private static float float_8;
	private static float float_9;
	private static float float_10;

	//Vector3
	private static Vector3 vector3_1;
	private static Vector3 vector3_2;
	private static Vector3 vector3_3;
	private static Vector3 vector3_4;
	private static Vector3 vector3_5;
	private static Vector3 vector3_6;
	private static Vector3 vector3_7;
	private static Vector3 vector3_8;
	private static Vector3 vector3_9;
	private static Vector3 vector3_10;

	#endregion

	#region GetVelocityTopTime (初速を加えた時、何秒後に頂点に達するかを求める)

	/// <summary>
	/// 初速を加えた時、何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(float _vec)
	{
		return GetVelocityTopTime(_vec, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時、何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec)
	{
		return GetVelocityTopTime(_vec, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時、何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec, Vector3 _gravity)
	{
		return GetVelocityTopTime(_vec.y, _gravity);
	}

	/// <summary>
	/// 初速を加えた時、何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec, float _gravity = DefaultGravitationalAcceleration)
	{
		return GetVelocityTopTime(_vec.y, new Vector3(0.0f, _gravity, 0.0f));
	}

	/// <summary>
	/// 初速を加えた時、何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(float _vec, Vector3 _gravity, float _mass = DefaultMass, float _drag = DefaultDrag)
	{
		return Mathf.Clamp(_vec / -_gravity.y, 0.0f, float.PositiveInfinity);
	}

	#endregion

	#region GetVelocityTopHeight (初速を加えた時の最高地点の高さを求める)
	/// <summary>
	/// 初速を加えた時の最高地点の高さを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startHeight">初速を加えた時の高さ</param>
	/// <returns></returns>
	public static float GetVelocityTopHeight(Vector3 _vec, Vector3 _startHeight)
	{
		return GetVelocityTopHeight(_vec.y, _startHeight.y, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時の最高地点の高さを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startHeight">初速を加えた時の高さ</param>
	/// <returns>最高地点の高さ</returns>
	public static float GetVelocityTopHeight(Vector3 _vec, float _startHeight)
	{
		return GetVelocityTopHeight(_vec.y, _startHeight, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時の最高地点の高さを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startHeight">初速を加えた時の高さ</param>
	/// <returns>最高地点の高さ</returns>
	public static float GetVelocityTopHeight(float _vec, Vector3 _startHeight)
	{
		return GetVelocityTopHeight(_vec, _startHeight.y, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時の最高地点の高さを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startHeight">初速を加えた時の高さ</param>
	/// <returns>最高地点の高さ</returns>
	public static float GetVelocityTopHeight(float _vec, float _startHeight)
	{
		return GetVelocityTopHeight(_vec, _startHeight, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時の最高地点の高さを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startHeight">初速を加えた時の高さ</param>
	/// <param name="_gravity">重力加速度</param>
	/// <param name="_mass">質量</param>
	/// <param name="_drag">空気抵抗</param>
	/// <returns>最高地点の高さ</returns>
	public static float GetVelocityTopHeight(float _vec, float _startHeight, Vector3 _gravity, float _mass = DefaultMass, float _drag = DefaultDrag)
	{
		//GetVelocityTopTime
		var t = Mathf.Clamp(_vec / -_gravity.y, 0.0f, float.PositiveInfinity);
		return (_vec * t) + (-0.5f * -_gravity.y * Mathf.Pow(t, 2.0f)) + _startHeight;
	}

	#endregion

	#region GetVelocityTopPos (初速を加えた時の最高地点の座標を求める)

	/// <summary>
	/// 初速を加えた時の最高地点の座標を求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startPos">初速を加えた時の高さ</param>
	/// <returns>最高地点の座標</returns>
	public static Vector3 GetVelocityTopPos(Vector3 _vec, Vector3 _startPos)
	{
		return GetVelocityTopPos(_vec, _startPos, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えた時の最高地点の座標を求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startPos">初速を加えた時の高さ</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns></returns>
	public static Vector3 GetVelocityToPos(Vector3 _vec, Vector3 _startPos, float _gravity = DefaultGravitationalAcceleration)
	{
		return GetVelocityTopPos(_vec, _startPos, new Vector3(0.0f, _gravity, 0.0f));
	}

	/// <summary>
	/// 初速を加えた時の最高地点の座標を求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_startPos">初速を加えた時の高さ</param>
	/// <param name="_gravity">重力加速度</param>
	/// <param name="_mass">質量</param>
	/// <param name="_drag">空気抵抗</param>
	/// <returns>最高地点の座標</returns>
	public static Vector3 GetVelocityTopPos(Vector3 _vec, Vector3 _startPos, Vector3 _gravity, float _mass = DefaultMass, float _drag = DefaultDrag)
	{
		//GetVelocityTopTime
		var t = Mathf.Clamp(_vec.y / -_gravity.y, 0.0f, float.PositiveInfinity);
		var h = (_vec.y * t) + (-0.5f * -_gravity.y * Mathf.Pow(t, 2.0f));
		return new Vector3(_vec.x * t, h, _vec.z * t) + _startPos;
	}


	#endregion

	#region GetVelocityTimeToPosition (初速を加えた後指定秒数後にどの座標にいるかを求める)

	/// <summary>
	/// 初速を加えた後指定秒数後にどの座標にいるか
	/// </summary>
	/// <param name="_vec"></param>
	/// <param name="_startPos"></param>
	/// <param name="_time"></param>
	/// <returns></returns>
	public static Vector3 GetVelocityTimeToPosition(Vector3 _vec, Vector3 _startPos, float _time)
	{
		return GetVelocityTimeToPosition(_vec, _startPos, _time, DefaultGravitationalAccelerationVec);
	}

	public static Vector3 GetVelocityTimeToPosition(Vector3 _vec, Vector3 _startPos, float _time, Vector3 _gravity, float _mass = DefaultMass, float _drag = DefaultDrag)
	{
		return new Vector3(_vec.x * _time, _vec.y * _time, _vec.z * _time) + _startPos;
	}

	#endregion

	#region GetFreeFallTime (空気抵抗を含む指定距離の自由落下する時間を求める)

	public static float GetFreeFallTime(float _height, float _gravity, float _mass, float _drag)
	{
		return Mathf.Sqrt(_mass / (-_gravity * _drag)) * (float)System.Math.Acos((_height * _drag) / _mass);
	}

	#endregion

	#region GetMagnusEffectVec (回転のベクトルからマグヌス効果で付与するベクトルを求める)

	public static Vector3 GetMagnusEffectVec(Vector3 _angleVelocity, Vector3 _velocity)
	{
		return Vector3.zero;
	}

	#endregion

	#region GetLineNearPoint(ある座標の直線上の一番近い座標を求める)

	/// <summary>
	/// ある座標の直線上の一番近い座標を求める
	/// </summary>
	/// <param name="_linePoint1">線のポイント１</param>
	/// <param name="_linePoint2">線のポイント２</param>
	/// <param name="_checkPoint">チェックする座標</param>
	/// <returns>直線状の一番近い座標</returns>
	public static Vector3 GetLineNearPoint(Vector3 _linePoint1, Vector3 _linePoint2, Vector3 _checkPoint)
	{
		return GetLineNearPoint(_linePoint1, _linePoint2, _checkPoint, false);
	}

	/// <summary>
	/// ある座標の直線上の一番近い座標を求める
	/// </summary>
	/// <param name="_linePoint1">線のポイント１</param>
	/// <param name="_linePoint2">線のポイント２</param>
	/// <param name="_checkPoint">チェックする座標</param>
	/// <param name="_isLimit">ポイントの間に制限をかけるか</param>
	/// <returns>直線状の一番近い座標</returns>
	public static Vector3 GetLineNearPoint(Vector3 _linePoint1, Vector3 _linePoint2, Vector3 _checkPoint, bool _isLimit = false)
	{
		var x = Vector3.Dot((_linePoint2 - _linePoint1).normalized, (_checkPoint - _linePoint1));
		if (_isLimit)
			x = Mathf.Clamp(x, 0.0f, Vector3.Distance(_linePoint1, _linePoint2));
		return _linePoint1 + (_linePoint2 - _linePoint1).normalized * x;
	}

	#endregion

	#region 交点を求める

	/// <summary>
	/// 円と線との交点を求める
	/// </summary>
	/// <param name="_linePoint1">線のポイント１</param>
	/// <param name="_linePoint2">線のポイント２</param>
	/// <param name="_circleCenter">円の中心座標</param>
	/// <param name="_circleRadius">円の半径</param>
	/// <param name="_intersectionPoint1">交点１</param>
	/// <param name="_intersectionPoint2">交点２</param>
	/// <returns>円と点が接するか</returns>
	public static bool GetIntersectionOfLineAndCircle(Vector2 _linePoint1, Vector2 _linePoint2, Vector2 _circleCenter, float _circleRadius, out Vector2 _intersectionPoint1, out Vector2 _intersectionPoint2)
	{
		float_1 = _linePoint2.y - _linePoint1.y;
		float_2 = _linePoint1.x - _linePoint2.x;
		float_3 = -((float_1 * _linePoint1.x) + (float_2 * _linePoint1.y));
		float_4 = (float_1 * float_1) + (float_2 * float_2);
		float_5 = float_1 * _circleCenter.x + float_2 * _circleCenter.y + float_3;
		float_6 = float_4 * _circleRadius * _circleRadius - float_5 * float_5;

		_intersectionPoint1 = Vector2.zero;
		_intersectionPoint2 = Vector2.zero;

		if (_linePoint1 == _linePoint2)
			return false;

		if (float_6 > 0)
		{
			float_7 = _circleCenter.x - (float_1 / float_4) * float_5;
			float_8 = _circleCenter.y - (float_2 / float_4) * float_5;
			float_9 = (float_2 / float_4) * Mathf.Sqrt(float_6);
			float_10 = (float_1 / float_4) * Mathf.Sqrt(float_6);
			_intersectionPoint1 = new Vector2(float_7 - float_9, float_8 + float_10);
			_intersectionPoint2 = new Vector2(float_7 + float_9, float_8 - float_10);
			return true;
		}
		else if (float_6 == 0)
		{
			var contactPoint = new Vector2(_circleCenter.x - float_1 * float_5 / float_4, _circleCenter.y - float_2 * float_5 / float_4);
			_intersectionPoint1 = contactPoint;
			_intersectionPoint2 = contactPoint;
			return true;
		}
		else
		{
			return false;
		}
	}


	public static bool GetIntersectionOfCircleAndCircle(Vector2 _circlePoint1, Vector2 _circlePoint2, float _circleRadius1, float _circleRadius2, out Vector2 _intersectionPoint1, out Vector2 _intersectionPoint2)
	{


	}


	#endregion

	#region

	/// <summary>
	/// ベクトルから角度に直す
	/// </summary>
	/// <param name="_vec">ベクトル</param>
	/// <returns>角度</returns>
	public static float VectorToAngle(Vector2 _vec)
	{
		return Mathf.Atan2(_vec.normalized.y, _vec.normalized.x) * Mathf.Rad2Deg;
	}
	
	#endregion

	#region ArraySum(配列内の要素を合計する)

	/// <summary>
	/// 配列内の要素を合計する
	/// </summary>
	/// <param name="_array">合計する配列</param>
	/// <returns>合計値</returns>
	public static int ArraySum(params int[] _array)
	{
		int sum = 0;
		for (int i = 0; i < _array.Length; i++)
			sum += _array[i];
		return sum;
	}

	/// <summary>
	/// 配列内の要素を合計する
	/// </summary>
	/// <param name="_array">合計する配列</param>
	/// <returns>合計値</returns>
	public static float ArraySum(params float[] _array)
	{
		float sum = 0;
		for (int i = 0; i < _array.Length; i++)
			sum += _array[i];
		return sum;
	}

	/// <summary>
	/// 配列内の要素を合計する
	/// </summary>
	/// <param name="_array">合計する配列</param>
	/// <returns>合計値</returns>
	public static string ArraySum(params string[] _array)
	{
		string sum = "";
		for (int i = 0; i < _array.Length; i++)
			sum += _array[i];
		return sum;
	}
	#endregion

	#region ArrayMax(配列内の要素で最大の値を返す)

	/// <summary>
	/// 配列内の最大値を返す
	/// </summary>
	/// <param name="_array">配列</param>
	/// <returns>最大値</returns>
	public static int ArrayMax(params int[] _array)
	{
		int max = _array[0];
		for (int i = 0; i < _array.Length; i++)
		{
			if (_array[i] > max)
				max = _array[i];
		}
		return max;
	}

	/// <summary>
	/// 配列内の最大値を返す
	/// </summary>
	/// <param name="_array">配列</param>
	/// <returns>最大値</returns>
	public static float ArrayMax(params float[] _array)
	{
		float max = _array[0];
		for (int i = 0; i < _array.Length; i++)
		{
			if (_array[i] > max)
				max = _array[i];
		}
		return max;
	}

	#endregion

	#region GetRandomIndex(重みづけされた配列からランダムな添え字を返す)

	/// <summary>
	/// 重みづけされた配列からランダムな添え字を返す
	/// 配列の要素が全て0の時は-1を返す
	/// </summary>
	/// <param name="_weightTable">重み付けされた配列</param>
	/// <returns>ランダムな添え字</returns>
	public static int GetRandomIndex(params int[] _weightTable)
	{
		float[] floatWeighttable = new float[_weightTable.Length];
		_weightTable.CopyTo(floatWeighttable, 0);
		return GetRandomIndex(floatWeighttable);
	}

	/// <summary>
	/// 重みづけされた配列からランダムな添え字を返す
	/// 配列の要素が全て0の時は-1を返す
	/// </summary>
	/// <param name="_weightTable">重み付けされた配列</param>
	/// <returns>ランダムな添え字</returns>
	public static int GetRandomIndex(params float[] _weightTable)
	{
		float totalWeight = ArraySum(_weightTable);
		float val = UnityEngine.Random.Range(0.0f, totalWeight);
		int retIndex = -1;
		for (int i = 0; i < _weightTable.Length; i++)
		{
			if (_weightTable[i] >= val)
			{
				retIndex = i;
				break;
			}
			val -= _weightTable[i];
		}
		return retIndex;
	}

	#endregion

	#region RandomDateTime(開始時間と終了時間をランダムで返す)
	/// <summary>
	///	開始時間と終了時間の間をランダムで返す計算をする
	/// </summary>
	/// <param name="_startDateTime">開始時間</param>
	/// <param name="_endDatetime">終了時間</param>
	/// <returns>開始時間～終了時間の間のランダムな時間</returns>
	public static DateTime RandomDateTime(DateTime _startDateTime, DateTime _endDatetime)
	{
		if (_startDateTime > _endDatetime)
			return _startDateTime;

		TimeSpan span = _endDatetime - _startDateTime;
		float ranSpan = UnityEngine.Random.Range(0, (float)span.TotalMilliseconds);
		return _startDateTime + TimeSpan.FromMilliseconds(ranSpan);
	}
	#endregion

}