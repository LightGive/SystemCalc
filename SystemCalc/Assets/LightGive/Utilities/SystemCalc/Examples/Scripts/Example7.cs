using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Example7 : MonoBehaviour
{
	[SerializeField]
	private Transform[] pointsSprite;
	[SerializeField]
	private LineRenderer m_line;
	[SerializeField]
	private InputField m_inputFieldVelocityX;
	[SerializeField]
	private InputField m_inputFieldVelocityY;
	[SerializeField]
	private Slider m_sliderInterval;
	[SerializeField]
	private Slider m_sliderPoints;
	[SerializeField]
	private Text m_textIntervalValue;
	[SerializeField]
	private Text m_textPointValue;
	[SerializeField]
	private Rigidbody2D m_ballRigid;
	[SerializeField]
	private Vector3 m_ballResetPos;


	void Update ()
	{
		float resultX = 0.0f;
		float resultY = 0.0f;
		if (float.TryParse(m_inputFieldVelocityX.text, out resultX) &&
			float.TryParse(m_inputFieldVelocityY.text, out resultY))
		{
			Vector3[] positions = SystemCalc.GetBallisticpredictionPoint(
				new Vector3(resultX, resultY), 
				m_ballResetPos, 
				(int)m_sliderPoints.value, 
				(float)m_sliderInterval.value);

			for (int i = 0; i < (int)m_line.positionCount; i++)
			{
				pointsSprite[i].gameObject.SetActive(i < positions.Length);
				if (i >= positions.Length)
				{
					m_line.SetPosition(i, positions[positions.Length - 1]);
				}
				else
				{
					pointsSprite[i].position = positions[i];
					m_line.SetPosition(i, positions[i]);
				}
			}
		}
	}

	public void OnButtonDownSimulate()
	{
		if (m_inputFieldVelocityX.text == "" || m_inputFieldVelocityY.text == "")
			return;

		m_ballRigid.simulated = false;
		m_ballRigid.transform.position = m_ballResetPos;
		m_ballRigid.velocity = Vector2.zero;
		m_ballRigid.simulated = true;
		m_ballRigid.velocity = new Vector2(float.Parse(m_inputFieldVelocityX.text), float.Parse(m_inputFieldVelocityY.text));
	}

	public void OnPoinsValueChange(Single _value)
	{
		m_textPointValue.text = _value.ToString("0");
	}

	public void OnPointIntervalValueChange(Single _value)
	{
		m_textIntervalValue.text = _value.ToString("F2");

	}
}
