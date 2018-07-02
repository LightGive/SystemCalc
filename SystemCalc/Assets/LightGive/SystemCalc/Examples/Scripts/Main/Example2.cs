using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Example2 : MonoBehaviour
{
	[SerializeField]
	private Transform m_intersectionPoint1;
	[SerializeField]
	private Transform m_intersectionPoint2;
	[SerializeField]
	private LineCircleDraw m_circle1;
	[SerializeField]
	private LineCircleDraw m_circle2;

	[SerializeField]
	private Slider m_sliderCircle1;
	[SerializeField]
	private Slider m_sliderCircle2;

	void Update()
	{
		var isContact = false;
		Vector2 point1 = Vector2.zero;
		Vector2 point2 = Vector2.zero;
		isContact = SystemCalc.GetIntersectionOfCircleAndCircle(
			new Vector2(m_circle1.transform.position.x, m_circle1.transform.position.y),
			m_circle1.radius,
			new Vector2(m_circle2.transform.position.x, m_circle2.transform.position.y),
			m_circle2.radius,
			out point1,
			out point2);

		if (isContact)
		{
			m_intersectionPoint1.gameObject.SetActive(true);
			m_intersectionPoint2.gameObject.SetActive(true);
			m_intersectionPoint1.position = point1;
			m_intersectionPoint2.position = point2;
		}
		else
		{
			m_intersectionPoint1.gameObject.SetActive(false);
			m_intersectionPoint2.gameObject.SetActive(false);
		}
	}

	public void OnChangeCircle1Radius(float _val)
	{
		m_circle1.radius = _val;
	}

	public void OnChangeCircle2Radius(float _val)
	{
		m_circle2.radius = _val;
	}
}
