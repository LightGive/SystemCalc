using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShot : MonoBehaviour
{
	private const float UP_POS = 10.0f;

	[SerializeField]
	private bool isMagnusEffect;

	[SerializeField]
	private GameObject targetObj;
	[SerializeField]
	private Vector3 vec;

	private int shotNo = 0;
	private Vector3 defaultPos;
	private Rigidbody rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody>();
		defaultPos = transform.position;

	}
	
	void Update ()
	{
		var t = 1.0f;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//最高地点までの時間を求める
			rigid.velocity = vec;
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));


			//最高地点の高さを求める
			rigid.velocity = vec;
			Debug.Log(SystemCalc.GetVelocityTopHeight(vec, transform.position));
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));


			//最高地点の座標を求める
			rigid.velocity = vec;
			StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
			targetObj.transform.position = SystemCalc.GetVelocityTopPos(vec, transform.position);


			//指定秒数後にどの座標にいるか
			rigid.velocity = vec;
			targetObj.transform.position = SystemCalc.GetVelocityTimeToPosition(vec, transform.position, t);
			StartCoroutine(WaitBreak(t));


			rigid.velocity = Vector3.zero;
			var pos = transform.position + new Vector3(0.0f, UP_POS, 0.0f);
			StartCoroutine(WaitBreak(SystemCalc.GetFreeFallTime(UP_POS, Physics.gravity.y, rigid.mass, rigid.drag)));
		}

		if (isMagnusEffect)
		{

		}
    }

	void Reset()
	{
		rigid.isKinematic = true;
		transform.position = defaultPos;
		rigid.isKinematic = false;
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

	public void AddNo(int _add)
	{
		shotNo += _add;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawSphere(transform.position + new Vector3(0.0f, UP_POS), 0.1f);
	}
}
