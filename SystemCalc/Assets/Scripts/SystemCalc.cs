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
	/// 通常の重力加速度のベクトル
	/// </summary>
	private static readonly Vector3 DefaultGravitationalAccelerationVec = new Vector3(0.0f, DefaultGravitationalAcceleration, 0.0f);

	#region GetVelocityTopTime (初速を加えて何秒後に頂点に達するかを求める)

	/// <summary>
	/// 初速を加えて何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(float _vec)
	{
		return GetVelocityTopTime(_vec, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えて何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec)
	{
		return GetVelocityTopTime(_vec, DefaultGravitationalAccelerationVec);
	}

	/// <summary>
	/// 初速を加えて何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec, Vector3 _gravity)
	{
		return GetVelocityTopTime(_vec.y, _gravity);
	}

	/// <summary>
	/// 初速を加えて何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(Vector3 _vec, float _gravity = DefaultGravitationalAcceleration)
	{
		return GetVelocityTopTime(_vec.y, new Vector3(0.0f, _gravity, 0.0f));
	}

	/// <summary>
	/// 初速を加えて何秒後に頂点に達するかを求める
	/// </summary>
	/// <param name="_vec">初速</param>
	/// <param name="_gravity">重力加速度</param>
	/// <returns>何秒後に頂点に到達するか</returns>
	public static float GetVelocityTopTime(float _vec, Vector3 _gravity, float _mass = DefaultMass, float _drag = DefaultDrag)
	{
		return Mathf.Clamp(_vec / -_gravity.y, 0.0f, float.PositiveInfinity);
	}

	#endregion


}