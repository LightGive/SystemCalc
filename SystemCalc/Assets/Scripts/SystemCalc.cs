using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 様々な計算を扱うクラス
/// </summary>
public static　class SystemCalc
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

	//物理など
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

	public static Vector3 GetVelocityTimeToPosition(Vector3 _vec, Vector3 _startPos, float _time, Vector3 _gravity, float _mass = DefaultMass, float _drag=DefaultDrag)
	{
		return new Vector3(_vec.x * _time, _vec.y * _time, _vec.z * _time) + _startPos;
	}

	#endregion

	#region GetFreeFallTime (空気抵抗を含む指定距離の自由落下する時間を求める)

	public static float GetFreeFallTime(float _height, float _gravity,float _mass, float _drag)
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


	#region GetCircleLineIntersection（円と線との交点を求める）

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
	public static bool GetCircleLineIntersection(Vector2 _linePoint1, Vector2 _linePoint2, Vector2 _circleCenter, float _circleRadius, out Vector2 _intersectionPoint1, out Vector2 _intersectionPoint2)
	{
		var a = _linePoint2.y - _linePoint1.y;
		var b = _linePoint1.x - _linePoint2.x;
		var c = -((a * _linePoint1.x) + (b * _linePoint1.y));
		var l = (a * a) + (b * b);
		var k = a * _circleCenter.x + b * _circleCenter.y + c;
		var d = l * _circleRadius * _circleRadius - k * k;

		_intersectionPoint1 = Vector2.zero;
		_intersectionPoint2 = Vector2.zero;

		if (_linePoint1 == _linePoint2)
			return false;

		if (d > 0)
		{
			var ds = Mathf.Sqrt(d);
			var apl = a / l;
			var bpl = b / l;
			var xc = _circleCenter.x - apl * k;
			var yc = _circleCenter.y - bpl * k;
			var xd = bpl * ds;
			var yd = apl * ds;
			_intersectionPoint1 = new Vector2(xc - xd, yc + yd);
			_intersectionPoint2 = new Vector2(xc + xd, yc - yd);
			return true;
		}
		else if (d == 0)
		{
			var contactPoint = new Vector2(_circleCenter.x - a * k / l, _circleCenter.y - b * k / l);
			_intersectionPoint1 = contactPoint;
			_intersectionPoint2 = contactPoint;
			return true;
		}
		else
		{
			return false;
		}
	}

	#endregion

	//配列など
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

	//乱数関係
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