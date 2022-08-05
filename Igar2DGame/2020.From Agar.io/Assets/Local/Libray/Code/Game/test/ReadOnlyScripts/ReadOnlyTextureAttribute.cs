using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

public class ReadOnlyTextureAttribute : ReadOnlyAttribute
{
    public float SizePercentage;

    public ReadOnlyTextureAttribute(float size)
    {
        SizePercentage = size;  
    }
    public ReadOnlyTextureAttribute()
    {
        SizePercentage = 0.25f;
    }

#if UNITY_EDITOR
    public static Dictionary<Texture, bool> foldout_dictionary = new Dictionary<Texture, bool>();

    public override void DrawInInspector(FieldInfo i, object o)
    {
        object value = i.GetValue(o);
        Texture t = value as Texture;
        if (t == null) return;
        GUILayout.BeginVertical();

        bool foldout = false;
        RenderTexture rt = value as RenderTexture;
        EditorGUILayout.LabelField(i.Name + " ( " + t.width + "x" + t.height);
        foldout_dictionary.TryGetValue(t, out foldout);
        foldout = EditorGUILayout.Foldout(foldout, value.ToString());
        foldout_dictionary[t] = foldout;


        if (foldout)
        {
            if (rt)
            {
                EditorGUILayout.LabelField(string.Format("AA[{0}]  MipMap[{1}]", rt.antiAliasing, rt.useMipMap));
                EditorGUILayout.LabelField(string.Format("Depth[{0}]  Format [{1}]", rt.depth, rt.format));
            }
            EditorGUILayout.LabelField(string.Format("Filter[{0}]  Wrap[{1}]  Aniso[{2}]", t.filterMode, t.wrapMode, t.anisoLevel));
        }
        GUILayout.Label(t);
        GUILayout.EndVertical();
    }
#endif
}
