using UnityEngine;
using UnityEditor;
using System.Reflection;
using Unity.Collections;
using System;

    [CustomEditor (typeof(MonoBehaviour), true)]
public class LibraryInspector : Editor
{

    private static bool show;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawReadOnlyFields();
    }
    public void DrawReadOnlyFields()
    {
        DrawReadOnlyFields(target);
    }
    public static void DrawReadOnlyFields(object target)
    {
        bool drewHeader = false;

        FieldInfo[] objectFields = target.GetType().GetFields(BindingFlags.Instance 
                                                            | BindingFlags.NonPublic);
        for (int i = 0; i < objectFields.Length; i++)
        {
            ReadOnlyAttribute attribute = Attribute.GetCustomAttribute(objectFields[i], 
                                         typeof(ReadOnlyAttribute)) as ReadOnlyAttribute;

            // if any attributes print out the data //
            if (attribute != null)
            {
                if (!drewHeader)
                {
                    GUILayout.BeginVertical();
                    GUILayout.Space(10);
                    drewHeader = true;
                    show = EditorGUILayout.Foldout(show, "Debug Info");
                    if (!show)
                        break;
                    EditorGUI.indentLevel++;
                }
                attribute.DrawInInspector(objectFields[i], target);
            }
        }
        if (drewHeader)
        {
            EditorGUI.indentLevel--;
            GUILayout.EndVertical();
        }

    }

}
