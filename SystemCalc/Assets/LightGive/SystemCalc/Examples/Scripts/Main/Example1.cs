using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example1: MonoBehaviour
{
	[SerializeField]
	private Transform m_p1;
	[SerializeField]
	private Transform m_p2;
	[SerializeField]
	private Transform m_intersectionPoint1;
	[SerializeField]
	private Transform m_intersectionPoint2;
	[SerializeField]
	private LineRenderer m_line;
	[SerializeField]
	private LineCircleDraw m_circle;

	//UI
	[SerializeField]
	private Text m_textValue;
	
	void Update ()
	{
		m_line.SetPosition(0, m_p1.position);
		m_line.SetPosition(1, m_p2.position);

		var contactPoint1 = Vector2.zero;
		var contactPoint2 = Vector2.zero;
		var h = Vector2.zero;

		if (SystemCalc.GetIntersectionOfLineAndCircle(
			new Vector2(m_p1.position.x, m_p1.position.y),
			new Vector2(m_p2.position.x, m_p2.position.y),
			new Vector2(m_circle.transform.position.x, m_circle.transform.position.y),
			m_circle.radius,
			out contactPoint1,
			out contactPoint2))
		{
			m_intersectionPoint1.gameObject.SetActive(!contactPoint1.Equals(Vector2.zero));
			m_intersectionPoint2.gameObject.SetActive(!contactPoint2.Equals(Vector2.zero));
			m_intersectionPoint1.position = contactPoint1;
			m_intersectionPoint2.position = contactPoint2;
		}
		else
		{
			m_intersectionPoint1.gameObject.SetActive(false);
			m_intersectionPoint2.gameObject.SetActive(false);
		}
	}

	public void OnSliderChange(float _val)
	{
		m_circle.radius = _val;
		m_textValue.text = _val.ToString("F1");
	}
}
