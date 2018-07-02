using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Example3 : MonoBehaviour {

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



	void Update ()
	{
		m_line.SetPosition(0, m_p1.position);
		m_line.SetPosition(1, m_p2.position);

		m_dragPoint.position = SystemCalc.GetLineNearPoint(m_p1.position, m_p2.position, m_nearPoint.position, true);
	}
}
