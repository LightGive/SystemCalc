using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Example : MonoBehaviour
{
	[SerializeField]
	private SceneInfo[] m_sceneInfo;
	[SerializeField]
	private Button m_buttonNext;
	[SerializeField]
	private Button m_buttonBack;
	[SerializeField]
	private Text m_textSceneTitle;

	private int m_nowSceneNo;

	private void Start()
	{
		m_nowSceneNo = 0;
		SceneChange();
	}

	public void OnButtonDownNextScene()
	{
		m_nowSceneNo = Mathf.Clamp(m_nowSceneNo + 1, 0, m_sceneInfo.Length-1);
		SceneChange();
	}
	public void OnButtonDownBackScene()
	{
		m_nowSceneNo = Mathf.Clamp(m_nowSceneNo - 1, 0, m_sceneInfo.Length-1);
		SceneChange();
	}

	public void SceneChange()
	{
		for (int i = 0; i < m_sceneInfo.Length;i++)
		{
			m_sceneInfo[i].gameObject.SetActive(i == m_nowSceneNo);
			m_sceneInfo[i].uiTransform.gameObject.SetActive(i == m_nowSceneNo);
		}

		m_textSceneTitle.text = (m_nowSceneNo + 1).ToString("00") + ". " + m_sceneInfo[m_nowSceneNo].sceneText;
	}
}

[System.Serializable]
public class SceneInfo
{
	public string sceneText;
	public GameObject gameObject;
	public Transform uiTransform;
}