using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DashEditor : EditorWindow
{
    float zValue;
    float xValue;
    int count = 5;
    GameObject parent;
    [MenuItem("Window/Dash")]
    public static void ShowWindow()
    {
        GetWindow<DashEditor>("DashEditor");
    }
    private void OnGUI()
    {
        GUILayout.Label("Create From  Selected Object", EditorStyles.boldLabel);
        GUILayout.Label("Z Value", EditorStyles.boldLabel);
        zValue = EditorGUILayout.FloatField(zValue);
        GUILayout.Label("X Value", EditorStyles.boldLabel);
        xValue = EditorGUILayout.FloatField(xValue);
        GUILayout.Label("Count", EditorStyles.boldLabel);
        count = EditorGUILayout.IntField(count);
        parent = GameObject.FindGameObjectWithTag("Parent");

        if (GUILayout.Button("Create"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject g = Instantiate(obj);
                    Vector3 pos = obj.transform.position;
                    pos.z += zValue * (i + 1);
                    pos.x += xValue * (i + 1);
                    g.transform.position = pos;
                    g.transform.SetParent(parent.transform);
                }


            }



        }

    }



}
