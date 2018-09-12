using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example9 : MonoBehaviour
{
	[SerializeField]
	private Text m_textFormula;
	[SerializeField]
	private InputField m_inputX1;
	[SerializeField]
	private InputField m_inputY1;
	[SerializeField]
	private InputField m_inputX2;
	[SerializeField]
	private InputField m_inputY2;

	public void InputText()
	{
		var x1 = 0.0f;
		var y1 = 0.0f;
		var x2 = 0.0f;
		var y2 = 0.0f;

		if (!float.TryParse(m_inputX1.text, out x1))
		{
			Debug.Log("Please input text all");
			return;
		}
		if (!float.TryParse(m_inputX2.text, out x2))
		{
			Debug.Log("Please input text all");
			return;
		}
		if (!float.TryParse(m_inputY1.text, out y1))
		{
			Debug.Log("Please input text all");
			return;
		}
		if (!float.TryParse(m_inputY2.text, out y2))
		{
			Debug.Log("Please input text all");
			return;
		}

		var ans = SystemCalc.GetQuadraticFunction(x1, y1, x2, y2);
		m_textFormula.text = "y = " + ans.a.ToString() + "x +" + ans.b.ToString();
	}
}
