using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example5 : MonoBehaviour
{
	[SerializeField]
	private InputField m_inputFieldVelocity;
	[SerializeField]
	private Transform m_line;
	[SerializeField]
	private Rigidbody2D m_ballRigid;
	[SerializeField]
	private Vector3 m_ballResetPos;


	private void Update()
	{
		float result = 0.0f;
		if (float.TryParse(m_inputFieldVelocity.text, out result))
		{
			var topHeight = SystemCalc.GetVelocityTopHeight(result, m_ballResetPos.y);
			m_line.transform.position = new Vector3(0.0f, topHeight, 0.0f);
		}
	}

	public void OnButtonDownSimulate()
	{
		if (m_inputFieldVelocity.text == "")
			return;

		m_ballRigid.simulated = false;
		m_ballRigid.transform.position = m_ballResetPos;
		m_ballRigid.simulated = true;
		m_ballRigid.velocity = new Vector2(0.0f, float.Parse(m_inputFieldVelocity.text));

		//m_ballRigid.AddForce(new Vector2(0.0f, float.Parse(m_inputFieldVelocity.text)), ForceMode2D.Impulse);
	}
}
