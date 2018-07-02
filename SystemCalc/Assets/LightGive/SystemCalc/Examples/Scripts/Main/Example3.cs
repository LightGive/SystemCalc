using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example3 : MonoBehaviour
{
	[SerializeField]
	private Transform m_p1;
	[SerializeField]
	private Transform m_p2;
	[SerializeField]
	private Transform m_nearPoint;
	[SerializeField]
	private Transform m_dragPoint;
	[SerializeField]
	private LineRenderer m_line;

	[SerializeField]
	private Text m_textValue;
	[SerializeField]
	private Toggle m_toggleIsLimit;

	void Update ()
	{
		m_line.SetPosition(0, m_p1.position);
		m_line.SetPosition(1, m_p2.position);

		var lerp = 0.0f;
		var nearPos = SystemCalc.GetLineNearPoint(m_p1.position, m_p2.position, m_nearPoint.position, m_toggleIsLimit.isOn, out lerp);
		nearPos.z = -1;
		m_dragPoint.position = nearPos;
		m_textValue.text = lerp.ToString("F2");
	}
}
