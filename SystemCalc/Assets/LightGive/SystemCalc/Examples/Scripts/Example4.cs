using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example4 : MonoBehaviour
{
	[SerializeField]
	private InputField m_inputFieldVelocity;
	[SerializeField]
	private InputField m_inputFieldTopArriveSec;
	[SerializeField]
	private Rigidbody2D m_ballRigid;
	[SerializeField]
	private Vector3 m_ballResetPos;

	private bool m_isSimulate = false;
	private float m_simulateTimeCnt = 0.0f;

	private void Update()
	{
		float result = 0.0f;
		if (!m_isSimulate && float.TryParse(m_inputFieldVelocity.text, out result))
		{
			m_inputFieldTopArriveSec.text = SystemCalc.GetVelocityTopTime(result).ToString("F2");
		}
		else if (m_isSimulate)
		{
			m_simulateTimeCnt -= Time.deltaTime;
			m_inputFieldTopArriveSec.text = m_simulateTimeCnt.ToString("F2");

			if (m_simulateTimeCnt <= 0.0f)
			{
				m_simulateTimeCnt = 0.0f;
				m_inputFieldTopArriveSec.text = "0.0";
				m_ballRigid.simulated = false;
				m_isSimulate = false;
			}
		}
	}


	public void OnButtonDownSimulate()
	{
		if (m_inputFieldVelocity.text == "" || m_isSimulate)
			return;

		m_ballRigid.simulated = false;
		m_ballRigid.transform.position = m_ballResetPos;
		m_isSimulate = true;
		m_ballRigid.simulated = true;
		m_ballRigid.velocity = new Vector2(0.0f, float.Parse(m_inputFieldVelocity.text));
		m_simulateTimeCnt = SystemCalc.GetVelocityTopTime(float.Parse(m_inputFieldVelocity.text));
	}
}
