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
	[SerializeField]
	private Text debugDiscriptionText;

	private int debugShotNo = 0;
	private string []discriptionStr;
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

        if (Input.GetKeyDown((KeyCode.R)))
        {
            Reset();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector3.zero;
            var pos = transform.position + new Vector3(0.0f, UP_POS, 0.0f);
            var v = Vector3.zero;
            if (SystemCalc.GetVelocityGroundFallTimeVec(ref v, pos, targetObj.transform.position,0.5f))
            {
                Debug.Log(v.ToString());
                rigid.velocity = v;
            }
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
			transform.position.z.ToString("F4") + ")\n";

		if(_pos != Vector3.zero)
		{
			str += "距離:" + Vector3.Distance(_pos, transform.position);
		}

		Debug.Log(str);
	}


	void OnDrawGizmos()
	{
		Gizmos.DrawSphere(transform.position + new Vector3(0.0f, UP_POS), 0.1f);
	}
}
