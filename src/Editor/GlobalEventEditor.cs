using UnityEngine;
using UnityEditor;

namespace Chankiyu22.UnityGlobalEvent
{

[CustomEditor(typeof(GlobalEvent))]
public class GlobalEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GlobalEvent globalEvent = (GlobalEvent) serializedObject.targetObject;

        Rect rect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width - 60, rect.height), globalEvent, typeof(GlobalEvent), false);
        EditorGUI.EndDisabledGroup();

        if (GUI.Button(new Rect(rect.xMax - 80, rect.y, 80, rect.height), "Invoke", EditorStyles.miniButtonRight))
        {
            globalEvent.Invoke();
        }

        EditorGUILayout.Space();

        RenderDescription();

        serializedObject.ApplyModifiedProperties();
    }

    void RenderDescription()
    {
        SerializedProperty descriptionProp = serializedObject.FindProperty("m_description");

        EditorGUILayout.LabelField("Description");

        Rect rect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight * 3);

        descriptionProp.stringValue = EditorGUI.TextArea(new Rect(rect.x, rect.y, rect.width, rect.height), descriptionProp.stringValue);
    }
}

}
