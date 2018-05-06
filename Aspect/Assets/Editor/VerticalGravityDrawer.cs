using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(VerticalGravity))]
public class VerticalGravityDrawer : SliderDrawer
{

    internal override string leftLabel()
    {
        return "bottom";
    }

    internal override string rightLabel()
    {
        return "top";
    }

    internal override SerializedProperty floatProperty(SerializedProperty property)
    {
        return property.FindPropertyRelative("gravity");
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
