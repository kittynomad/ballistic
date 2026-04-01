using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(AbstractSerializer))]
public class AbstractSerializerDrawer : PropertyDrawer
{
    private int boundsSpace = 1;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return base.GetPropertyHeight(property, label);
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        Type t = fieldInfo.FieldType;

        string className = property.managedReferenceValue.GetType().Name == null ? "noname" : property.managedReferenceValue.GetType().Name;

        Rect dropdownBounds = position;
        dropdownBounds.x += EditorGUIUtility.labelWidth + boundsSpace;
        dropdownBounds.width -= EditorGUIUtility.labelWidth + boundsSpace;

        dropdownBounds.height = EditorGUIUtility.singleLineHeight;

        if(EditorGUI.DropdownButton(dropdownBounds, new(className), FocusType.Keyboard))
        {
            GenericMenu ASMenu = new GenericMenu();

            //default option
            ASMenu.AddItem(new GUIContent("None"), property.managedReferenceValue == null, () =>
            {
                property.managedReferenceValue = null;
                property.serializedObject.ApplyModifiedProperties();
            }
            );

            foreach(Type c in GetAllNonAbstractInheritingClasses(t))
            {
                ASMenu.AddItem(new GUIContent(c.Name), className == c.Name, () =>
                {
                    property.managedReferenceValue = c.GetConstructor(Type.EmptyTypes);
                    property.serializedObject.ApplyModifiedProperties();
                }
                );
            }

            ASMenu.ShowAsContext();
        }

        EditorGUI.PropertyField(position, property, label, true);
    }

    public IEnumerable GetAllNonAbstractInheritingClasses(Type rootClass)
    {
        List<Type> output = new List<Type>();
        Type[] allClasses = Assembly.GetAssembly(rootClass).GetTypes();
        
        for(int i = 0; i < allClasses.Length; i++)
        {
            if(!allClasses[i].IsAbstract)
            {
                output.Add(allClasses[i]);
            }
        }
        return output;
    }
}
#endif
