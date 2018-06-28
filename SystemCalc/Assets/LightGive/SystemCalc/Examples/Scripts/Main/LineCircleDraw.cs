using UnityEngine;

/// <summary>
/// LineRendererで円を描く
/// </summary>
[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class LineCircleDraw : MonoBehaviour
{
	[SerializeField,Range(4, 1000),Tooltip("円の頂点数")]
	private int verticesCount = 60;
	[SerializeField, Tooltip("円の倍率")]
	private Vector2 radiusMagnification = Vector2.one;
	[SerializeField, Tooltip("半径")]
	private float radius = 1.0f;
	[SerializeField, Tooltip("円の軸")]
	private Axis axis = Axis.Z;

	private LineRenderer line;

	/// <summary>
	/// 半径
	/// </summary>
	public float Radius
	{
		get { return radius; }
	}

	public enum Axis { X, Y, Z };

	/// <summary>
	/// 開始処理
	/// </summary>
	void Start()
	{
		line = gameObject.GetComponent<LineRenderer>();
		line.useWorldSpace = false;
		line.loop = true;
		CreateCircle();
	}

	/// <summary>
	/// インスペクタの値を変えた時、円を再作成する
	/// </summary>
	private void OnValidate()
	{
		CreateCircle();
	}

	/// <summary>
	/// 円を作成する
	/// </summary>
	[ContextMenu("CreateCircle")]
	void CreateCircle()
	{
		if (line == null)
			line = GetComponent<LineRenderer>();

		line.positionCount = (verticesCount + 1);

		float x, y, z = 0.0f;
		float angle = 0.0f;

		for (int i = 0; i < (verticesCount + 1); i++)
		{
			x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius * radiusMagnification.x;
			y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius * radiusMagnification.y;

			switch (axis)
			{
				case Axis.X: line.SetPosition(i, new Vector3(z, y, x)); break;
				case Axis.Y: line.SetPosition(i, new Vector3(y, z, x)); break;
				case Axis.Z: line.SetPosition(i, new Vector3(x, y, z)); break;
				default: break;
			}

			angle += (360.0f / verticesCount);
		}
	}
}