using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatingOrigin))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FloatingOrigin exam = (FloatingOrigin)target;
        if (GUILayout.Button("Move Origin"))
        {
            exam.MoveOriginButton();
        }
    }
}