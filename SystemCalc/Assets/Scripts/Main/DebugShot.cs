using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShot : MonoBehaviour
{
	[SerializeField]
	private Vector3 vec;

	private Rigidbody rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		//スペースキーを押したときに球を飛ばす
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			rigid.velocity = vec;
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			rigid.velocity = vec;
			Debug.Log(SystemCalc.GetVelocityTopHeight(vec, transform.position));
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
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
