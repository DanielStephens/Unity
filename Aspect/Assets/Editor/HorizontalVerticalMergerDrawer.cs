using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(WidthHeightMerger))]
public class WidthHeightMergerDrawer : SliderDrawer
{

    internal override string leftLabel()
    {
        return "width";
    }

    internal override string rightLabel()
    {
        return "height";
    }

    internal override SerializedProperty floatProperty(SerializedProperty property)
    {
        return property.FindPropertyRelative("merge");
    }

    internal override float lowerLimit()
    {
        return -1f;
    }

    internal override float upperLimit()
    {
        return 1f;
    }

}
