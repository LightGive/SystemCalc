using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleToCirclePoint : MonoBehaviour
{

	[SerializeField]
	private Transform intersectionPoint1;
	[SerializeField]
	private Transform intersectionPoint2;
	[SerializeField]
	private LineCircleDraw circle1;
	[SerializeField]
	private LineCircleDraw circle2;


	void Start()
	{

	}

	void Update()
	{
		var isContact = false;
		Vector2 point1 = Vector2.zero;
		Vector2 point2 = Vector2.zero;
		isContact = SystemCalc.GetIntersectionOfCircleAndCircle(
			new Vector2(circle1.transform.position.x, circle1.transform.position.y),
			circle1.radius,
			new Vector2(circle2.transform.position.x, circle2.transform.position.y),
			circle2.radius,
			out point1,
			out point2);

		if (isContact)
		{
			intersectionPoint1.position = point1;
			intersectionPoint2.position = point2;
		}
		else
		{
			intersectionPoint1.gameObject.SetActive(false);
			intersectionPoint2.gameObject.SetActive(false);
		}
	}
}
