using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDrag : MonoBehaviour
{
	[SerializeField]
	private float m_zPosition = 0.0f;

	private bool m_isDrag;

	private void OnMouseDown()
	{
		m_isDrag = true;
	}

	private void OnMouseUp()
	{
		m_isDrag = false;
	}

	private void OnMouseDrag()
	{
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = m_zPosition;
		transform.position = pos;
	}
}
