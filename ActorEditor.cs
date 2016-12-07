using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(Actor))] //编辑对应的脚本
public class ActorEditor : Editor
{

	//private string mPath1 = "";
	private Actor mActor;

	public override void OnInspectorGUI()
	{
		Actor t = (Actor)target;
		mActor = t;

		t.mName = EditorGUILayout.TextField("name", t.mName);
		t.mAge = EditorGUILayout.IntField("age", t.mAge);
		//t.mIsMale = ETCGuiTools.Toggle("male", t.mIsMale);
		t.transform.position = EditorGUILayout.Vector3Field("position", t.transform.position);

		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal(); 
		GUILayout.Label("Path:");
		t.mPath = EditorGUILayout.TextField(t.mPath);
		if (GUILayout.Button("Browse"))
			EditorApplication.delayCall += Save; 
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		t.mCurve = EditorGUILayout.CurveField("Curves:", t.mCurve);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Color:");
		t.mColor = EditorGUILayout.ColorField(t.mColor);
		EditorGUILayout.EndHorizontal();
	}

	/// <summary>
	/// 选择资源存储路径
	/// </summary>
	void Save ()
	{
		string path = EditorUtility.OpenFolderPanel ("Save", "", "");
		if (path.Length != 0) {
			//mPath1 = path;
			mActor.mPath = path; 
			EditorUtility.FocusProjectWindow ();
		}
	}
}