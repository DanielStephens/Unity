using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(HorizontalGravity))]
public class HorizontalGravityDrawer : SliderDrawer
{

    internal override string leftLabel()
    {
        return "left";
    }

    internal override string rightLabel()
    {
        return "right";
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
