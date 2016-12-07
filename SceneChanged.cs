
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

/// <summary>
/// Scene中的按钮扩展：
/// </summary>
[CustomEditor(typeof(MonoBehaviour), true)]
public class SceneRealTimeFocusEditor : Editor
{
    public void OnEnable()
    {
        active = false;
    }
    public void OnDisable()
    {
        active = false;
    }

    private bool active = false;
    void OnSceneGUI()
    {
        GameObject[] gos = Selection.gameObjects;
        if (gos != null)
        //if (Selection.activeTransform != null)
        {

            Handles.BeginGUI();
            GUILayout.BeginArea(new Rect(0, 0, 200, 200));
            if (!active)
            {
                if (GUILayout.Button("Active Real Time Trace", GUILayout.Height(30)))
                {
                    active = true;
                }
            }
            else
            {
                if (GUILayout.Button("Close Real Time Trace", GUILayout.Height(30)))
                {
                    active = false;
                }
            }
            GUILayout.EndArea();
            Handles.EndGUI();

            if (active)
            {
                SceneView.lastActiveSceneView.pivot = gos[0].transform.position;
                //SceneView.lastActiveSceneView.pivot = Selection.activeTransform.position;
                SceneView.lastActiveSceneView.Repaint();
            }
        }
    }
}
