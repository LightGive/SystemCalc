using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShot : MonoBehaviour
{
	[SerializeField]
	private bool isMagnusEffect;

	[SerializeField]
	private GameObject targetObj;
	[SerializeField]
	private Vector3 vec;

	private Rigidbody rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		var t = 1.0f;

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//最高地点までの時間を求める
			rigid.velocity = vec;
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			//最高地点の高さを求める
			rigid.velocity = vec;
			Debug.Log(SystemCalc.GetVelocityTopHeight(vec, transform.position));
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			rigid.velocity = vec;
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
			targetObj.transform.position = SystemCalc.GetVelocityTopPos(vec, transform.position);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			rigid.velocity = vec;
			targetObj.transform.position = SystemCalc.GetVelocityTimeToPosition(vec, transform.position, t);
			StartCoroutine(WaitBreak(t));
		}

		if (isMagnusEffect)
		{

		}
    }

	private IEnumerator WaitBreak(float _waitTime)
	{
		yield return new WaitForSeconds(_waitTime);
		Debug.Log("経過時間" + _waitTime);
		Debug.Log("現在の座標(" +
			transform.position.x.ToString("F4") + " , " +
			transform.position.y.ToString("F4") + " , " +
			transform.position.z.ToString("F4"));
		Debug.Break();
	}
}
