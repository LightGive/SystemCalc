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
	}

	private IEnumerator WaitBreak(float _waitTime)
	{
		yield return new WaitForSeconds(_waitTime);
		Debug.Log(_waitTime);
		Debug.Break();
	}
}
