using UnityEngine;

using System.Collections;

using UnityEditor;
using System;


public class TestDrag : EditorWindow {



	string path;

	Rect rect;
	string str;


	[MenuItem("Window/DragAndFind")]

	static void Init()

	{

		EditorWindow.GetWindow(typeof(TestDrag));

	}



	void OnGUI()

	{

		EditorGUILayout.LabelField("Drag File into Here");



		rect = EditorGUILayout.GetControlRect(GUILayout.Width(300));

		rect = EditorGUILayout.GetControlRect(GUILayout.Height(90));

		str = EditorGUI.TextField(rect, str);





		if ((Event.current.type == EventType.DragUpdated

			|| Event.current.type == EventType.DragExited)

			&& rect.Contains(Event.current.mousePosition))

		{



			DragAndDrop.visualMode = DragAndDropVisualMode.Generic;

			if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)

			{
				str = Application.dataPath + DragAndDrop.paths[0];
			}
		}

	}

}