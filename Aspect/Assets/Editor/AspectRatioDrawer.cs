using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AspectRatio))]
public class AspectRatioDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Calculate property widths to include our centre colon
        int dividerSize = 20;
        float propWidth = (position.width - dividerSize) / 2;

        // Calculate rects
        Rect widthRect = new Rect(position.x, position.y, propWidth, position.height);
        Rect dividerRect = new Rect(position.x + propWidth, position.y, dividerSize, position.height);
        Rect heightRect = new Rect(position.x + propWidth + dividerSize, position.y, propWidth, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        property.FindPropertyRelative("width").intValue = Mathf.Clamp(EditorGUI.IntField(widthRect, GUIContent.none, property.FindPropertyRelative("width").intValue), 1, 100);
        property.FindPropertyRelative("height").intValue = Mathf.Clamp(EditorGUI.IntField(heightRect, GUIContent.none, property.FindPropertyRelative("height").intValue), 1, 100);

        // Put the divider in the middle
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.LowerCenter;
        EditorGUI.LabelField(dividerRect, ":", style);
        
        EditorGUI.EndProperty();
    }

}
