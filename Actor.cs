using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	#region public member
	public Vector3 lookAtPoint = Vector3.zero;
	public int mAge;
	public string mName;
	//public bool mIsMale;
	public string mPath;
	public AnimationCurve mCurve;
	public Color mColor;
	#endregion
}
