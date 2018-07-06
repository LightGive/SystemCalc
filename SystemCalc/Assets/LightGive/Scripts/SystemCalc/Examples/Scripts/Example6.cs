using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example6 : MonoBehaviour
{
	[SerializeField]
	private InputField m_inputFieldVelocityX;
	[SerializeField]
	private InputField m_inputFieldVelocityY;
	[SerializeField]
	private InputField m_inputFieldTime;
	[SerializeField]
	private Transform m_arrivePoint;
	[SerializeField]
	private Vector3 m_ballResetPos;
	[SerializeField]
	private Rigidbody2D m_ballRigid;

	void Update ()
	{
		float resultX = 0.0f;
		float resultY = 0.0f;
		float resultTime = 0.0f;
		if (float.TryParse(m_inputFieldVelocityX.text, out resultX) && 
		    float.TryParse(m_inputFieldVelocityY.text, out resultY) &&
		    float.TryParse(m_inputFieldTime.text, out resultTime))
		{
			m_arrivePoint.position = SystemCalc.GetVelocityTimeToPosition(new Vector3(resultX, resultY, 0.0f), m_ballResetPos, resultTime);
		}

	}

	public void OnButtonDownSimulate()
	{
		if (m_inputFieldVelocityX.text == "" || m_inputFieldVelocityY.text == "" || m_inputFieldTime.text == "")
			return;

		m_ballRigid.simulated = false;
		m_ballRigid.transform.position = m_ballResetPos;
		m_ballRigid.velocity = Vector2.zero;
		m_ballRigid.simulated = true;
		m_ballRigid.velocity = new Vector2(float.Parse(m_inputFieldVelocityX.text), float.Parse(m_inputFieldVelocityY.text));
	}
}
