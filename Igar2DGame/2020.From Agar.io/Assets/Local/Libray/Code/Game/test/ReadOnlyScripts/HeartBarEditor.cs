using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(HeartBarEditor))]
public class HeartBarEditor : LibraryInspector
{
    [ReadOnlyAttribute]
    private int _maxValue, _currentValue;
}
