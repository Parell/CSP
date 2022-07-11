using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScaledSpace))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScaledSpace exam = (ScaledSpace)target;
        if (GUILayout.Button("Move Origin"))
        {
            exam.MoveOriginButton();
        }
    }
}