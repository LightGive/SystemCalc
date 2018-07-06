using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example8 : MonoBehaviour
{
	[SerializeField]
	private Transform m_arrow;
	[SerializeField]
	private Transform m_dragObject;
	[SerializeField]
	private InputField m_inputFieldAngle;

	void Update ()
	{
		var angle = SystemCalc.VectorToAngle(m_dragObject.position - m_arrow.position);
		m_arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
		m_inputFieldAngle.text = angle.ToString("F3");
	}
}
