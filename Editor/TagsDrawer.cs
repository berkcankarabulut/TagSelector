using TagSelector.Runtime;
using UnityEngine;
using UnityEditor;

namespace TagSelector.Editor
{
    [CustomPropertyDrawer(typeof(TagsAttribute))]
    public class TagsDrawer : PropertyDrawer
    {  
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    {
                        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;
                        int index = Mathf.Max(0, System.Array.IndexOf(tags, property.stringValue));

                        index = EditorGUI.Popup(position, label.text, index, tags);
                        property.stringValue = tags[index];
                        break;
                    }
                case SerializedPropertyType.Generic when property.isArray:
                    {
                        EditorGUI.LabelField(position, label);
                        
                        float LABEL_PADDING = 5f;
                        float SIZE_FIELD_WIDTH = 40f;
                        float lineHeight = EditorGUIUtility.singleLineHeight;
                        float labelWidth = EditorGUIUtility.labelWidth + LABEL_PADDING;

                        Rect sizeRect = new Rect(position.x + labelWidth, position.y, SIZE_FIELD_WIDTH, lineHeight);
                        property.arraySize = EditorGUI.IntField(sizeRect, property.arraySize);

                        for (int i = 0; i < property.arraySize; i++)
                        {
                            SerializedProperty element = property.GetArrayElementAtIndex(i);
                            Rect elementRect = new Rect(position.x, position.y + (i + 1) * lineHeight, position.width, lineHeight);

                            if (element.propertyType == SerializedPropertyType.String)
                            {
                                string[] tags = UnityEditorInternal.InternalEditorUtility.tags;
                                int index = Mathf.Max(0, System.Array.IndexOf(tags, element.stringValue));
                                index = EditorGUI.Popup(elementRect, $"Tag {i + 1}", index, tags);
                                element.stringValue = tags[index];
                            }
                        }

                        break;
                    }
                default:
                    EditorGUI.PropertyField(position, property, label);
                    break;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineHeight = EditorGUIUtility.singleLineHeight;

            if (property.isArray)
            {
                float spacingFactor = 10f;
                return lineHeight + ((property.arraySize * lineHeight) / spacingFactor);
            }

            return lineHeight;
        }
    }

}
