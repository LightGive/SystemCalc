using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCircleTest : MonoBehaviour
{
	[SerializeField]
	private Transform p1;
	[SerializeField]
	private Transform p2;
	[SerializeField]
	private Transform intersectionPoint1;
	[SerializeField]
	private Transform intersectionPoint2;
	[SerializeField]
	private LineRenderer line;
	[SerializeField]
	private LineCircleDraw circle;

	void Start ()
	{
		line.positionCount = 2;	
	}
	
	void Update ()
	{
		line.SetPosition(0, p1.position);
		line.SetPosition(1, p2.position);

		var contactPoint1 = Vector2.zero;
		var contactPoint2 = Vector2.zero;

		if (SystemCalc.GetIntersectionOfLineAndCircle(
			new Vector2(p1.position.x,p1.position.y), 
			new Vector2(p2.position.x, p2.position.y),
			new Vector2(circle.transform.position.x, circle.transform.position.y),
			circle.radius,
			out contactPoint1,
			out contactPoint2))
		{
			intersectionPoint1.position = contactPoint1;
			intersectionPoint2.position = contactPoint2;
		}
	}
}
