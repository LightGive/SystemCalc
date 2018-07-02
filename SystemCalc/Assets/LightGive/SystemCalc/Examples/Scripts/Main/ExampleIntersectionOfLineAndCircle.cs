using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleIntersectionOfLineAndCircle: MonoBehaviour
{
	[SerializeField]
	private Transform m_p1;
	[SerializeField]
	private Transform m_p2;
	[SerializeField]
	private Transform intersectionPoint1;
	[SerializeField]
	private Transform intersectionPoint2;
	[SerializeField]
	private LineRenderer line;
	[SerializeField]
	private LineCircleDraw circle;
	[SerializeField]
	private InputField m_inputFieldCircleRad;

	
	void Update ()
	{
		line.SetPosition(0, m_p1.position);
		line.SetPosition(1, m_p2.position);

		var contactPoint1 = Vector2.zero;
		var contactPoint2 = Vector2.zero;
		var h = Vector2.zero;

		if (SystemCalc.GetIntersectionOfLineAndCircle(
			new Vector2(m_p1.position.x, m_p1.position.y),
			new Vector2(m_p2.position.x, m_p2.position.y),
			new Vector2(circle.transform.position.x, circle.transform.position.y),
			circle.radius,
			out contactPoint1,
			out contactPoint2))
		{
			intersectionPoint1.gameObject.SetActive(!contactPoint1.Equals(Vector2.zero));
			intersectionPoint2.gameObject.SetActive(!contactPoint2.Equals(Vector2.zero));
			intersectionPoint1.position = contactPoint1;
			intersectionPoint2.position = contactPoint2;
		}
		else
		{
			intersectionPoint1.gameObject.SetActive(false);
			intersectionPoint2.gameObject.SetActive(false);
		}
	}
}
