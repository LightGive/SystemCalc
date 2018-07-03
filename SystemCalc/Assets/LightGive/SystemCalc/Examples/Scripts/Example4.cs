using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example4 : MonoBehaviour
{
	[SerializeField]
	private InputField m_inputFieldVelocity;
	[SerializeField]
	private InputField m_inputFIeldVelocity;
	[SerializeField]
	private Rigidbody2D m_ballRigid;
	[SerializeField]
	private Vector3 m_ballResetPos;


	public void OnButtonDownReset()
	{
		m_ballRigid.isKinematic = true;
		m_ballRigid.transform.position = m_ballResetPos;
	}

	public void OnButtonDownSimulate()
	{
		m_ballRigid.isKinematic = false;
		m_ballRigid.AddForce(new Vector2(0.0f, float.Parse(m_inputFieldVelocity.text)));
	}
}
