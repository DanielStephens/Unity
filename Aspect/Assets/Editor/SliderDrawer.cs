using UnityEngine;
using UnityEditor;
using System;

public abstract class SliderDrawer : PropertyDrawer
{

    private float labelMin = 12;
    private float sliderDesiredWidth = 40;
    private float sliderMinimumWidth = 20;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        position = drawFloat(position, floatProperty(property));

        float labelAllowance = calculateLabelAllowance(position);
        drawAdvice(position, labelAllowance, floatProperty(property));
        
        EditorGUI.EndProperty();
    }

    private float calculateLabelAllowance(Rect position)
    {
        float labelAllowance = 0;
        if (position.width > sliderDesiredWidth + (2 * labelMin))
        {
            labelAllowance = position.width - sliderDesiredWidth;
        }
        else if (position.width > sliderMinimumWidth + (2 * labelMin))
        {
            labelAllowance = (2 * labelMin);
        }

        return labelAllowance;
    }

    private void drawAdvice(Rect position, float labelAllowance, SerializedProperty property)
    {
        float leftLabelWidth = 0;
        float rightLabelWidth = 0;
        
        if(labelAllowance >= labelMin * 2)
        {
            float desiredLeftLabelWidth = EditorStyles.label.CalcSize(new GUIContent(leftLabel())).x;
            float desiredRightLabelWidth = EditorStyles.label.CalcSize(new GUIContent(rightLabel())).x;

            float lExtra = desiredLeftLabelWidth - labelMin;
            float rExtra = desiredRightLabelWidth - labelMin;
            float extra = lExtra + rExtra;

            float diff = labelAllowance - (labelMin * 2);

            float lDiff = (lExtra / extra) * diff;
            float rDiff = (rExtra / extra) * diff;

            leftLabelWidth = Mathf.Min(labelMin + lDiff, desiredLeftLabelWidth);
            rightLabelWidth = Mathf.Min(labelMin + rDiff, desiredRightLabelWidth);
        }

        float sliderWidth = position.width - leftLabelWidth - rightLabelWidth;

        Rect leftLabelRect = new Rect(position.x, position.y, leftLabelWidth, position.height);
        Rect sliderRect = new Rect(position.x + leftLabelWidth, position.y, sliderWidth, position.height);
        Rect rightLabelRect = new Rect(position.x + leftLabelWidth + sliderWidth, position.y, rightLabelWidth, position.height);

        EditorGUI.LabelField(leftLabelRect, leftLabel());
        property.floatValue = GUI.HorizontalSlider(sliderRect, property.floatValue, lowerLimit(), upperLimit());
        EditorGUI.LabelField(rightLabelRect, rightLabel());
    }

    private Rect drawFloat(Rect position, SerializedProperty property)
    {
        Rect valueRect = new Rect(position.x + (position.width - 50), position.y, 50, position.height);
        property.floatValue = Mathf.Clamp(EditorGUI.FloatField(valueRect, GUIContent.none, property.floatValue), lowerLimit(), upperLimit());
        return new Rect(position.x, position.y, position.width - 50, position.height);
    }

    internal abstract string leftLabel();

    internal abstract string rightLabel();

    internal abstract SerializedProperty floatProperty(SerializedProperty property);

    internal abstract float lowerLimit();

    internal abstract float upperLimit();

}
