using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugShot : MonoBehaviour
{
	private const float UP_POS = 10.0f;

	[SerializeField]
	private bool isMagnusEffect;

	[SerializeField]
	private GameObject targetObj;
	[SerializeField]
	private Vector3 vec;
	[SerializeField]
	private float t;
	[SerializeField]
	private Text debugNoText;

	private int debugShotNo = 0;
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







			rigid.velocity = Vector3.zero;
			var pos = transform.position + new Vector3(0.0f, UP_POS, 0.0f);
			StartCoroutine(WaitBreak(SystemCalc.GetFreeFallTime(UP_POS, Physics.gravity.y, rigid.mass, rigid.drag)));
		}

		if (isMagnusEffect)
		{

		}
    }

	public void Reset()
	{
		rigid.isKinematic = true;
		transform.position = defaultPos;
		rigid.velocity = Vector3.zero;
		rigid.isKinematic = false;
	}

	private IEnumerator WaitBreak(float _waitTime)
	{
		StartCoroutine(WaitBreak(_waitTime, Vector3.zero));
		yield break;
	}

	private IEnumerator WaitBreak(float _waitTime, Vector3 _pos)
	{
		yield return new WaitForSeconds(_waitTime);

		string str = "";
		str += "経過時間:" + _waitTime + "\n";
		str += "現在の座標:(" +
			transform.position.x.ToString("F4") + " , " +
			transform.position.y.ToString("F4") + " , " +
			transform.position.z.ToString("F4") + "\n";

		if(_pos != Vector3.zero)
		{
			str += "距離:" + Vector3.Distance(_pos, transform.position);
		}

		Debug.Log(str);
		Debug.Break();
	}

	public void AddNo(int _add)
	{
		debugShotNo = Mathf.Clamp(debugShotNo + _add, 0, 4);
		debugNoText.text = debugShotNo.ToString("00");
	}

	public void DebugStart()
	{
		switch (debugShotNo)
		{
			case 0:
				//最高地点までの時間を求める
				rigid.velocity = vec;
				StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
				break;
			case 1:
				//最高地点の高さを求める
				rigid.velocity = vec;
				Debug.Log(SystemCalc.GetVelocityTopHeight(vec, transform.position));
				StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
				break;
			case 2:
				//最高地点の座標を求める
				rigid.velocity = vec;
				StartCoroutine(WaitBreak(SystemCalc.GetVelocityTopTime(vec)));
				targetObj.transform.position = SystemCalc.GetVelocityTopPos(vec, transform.position);
				break;
			case 3:         
				//指定秒数後にどの座標にいるか
				rigid.velocity = vec;
				targetObj.transform.position = SystemCalc.GetVelocityTimeToPosition(vec, transform.position, t);
				StartCoroutine(WaitBreak(t));
				break;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawSphere(transform.position + new Vector3(0.0f, UP_POS), 0.1f);
	}
}
