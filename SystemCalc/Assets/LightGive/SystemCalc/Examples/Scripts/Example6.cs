using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example6 : MonoBehaviour
{
	[SerializeField]
	private InputField m_inputFieldVelocity_x;
	[SerializeField]
	private InputField m_inputFieldVelocity_y;
	[SerializeField]
	private Transform m_topPoint;
	[SerializeField]
	private Rigidbody2D m_ballRigid;
	[SerializeField]
	private Vector3 m_ballResetPos;

	void Update()
	{

		float resultX = 0.0f;
		float resultY = 0.0f;
		if (float.TryParse(m_inputFieldVelocity_x.text, out resultX) && float.TryParse(m_inputFieldVelocity_y.text, out resultY))
		{
			m_topPoint.position = SystemCalc.GetVelocityTopPos(
					new Vector3(float.Parse(m_inputFieldVelocity_x.text), float.Parse(m_inputFieldVelocity_y.text)),
					m_ballResetPos);
		}
	} 

	public void OnButtonDownSimulate()
	{
		if (m_inputFieldVelocity_x.text == ""||m_inputFieldVelocity_y.text == "")
			return;

		m_ballRigid.simulated = false;
		m_ballRigid.transform.position = m_ballResetPos;
		m_ballRigid.velocity = Vector2.zero;
		m_ballRigid.simulated = true;
		m_ballRigid.AddForce(new Vector2(float.Parse(m_inputFieldVelocity_x.text), float.Parse(m_inputFieldVelocity_y.text)), ForceMode2D.Impulse);
	}
}
