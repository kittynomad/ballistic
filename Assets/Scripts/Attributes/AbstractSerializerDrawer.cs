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

        string className;
        try
        {
            className = property.managedReferenceValue.GetType().Name == null ? "noname" : property.managedReferenceValue.GetType().Name;
        }
        catch
        {
            className = "None";
        }
        
        //set the dimensions of the dropdown
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

            //add dropdown option for each valid script
            foreach(Type c in GetAllNonAbstractInheritingClasses(t))
            {
                ASMenu.AddItem(new GUIContent(c.Name), className == c.Name, () =>
                {
                    property.managedReferenceValue = c.GetConstructor(Type.EmptyTypes).Invoke(null);
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
            //only add class if inheriting from target class AND not abstract (naturally)
            if(rootClass.IsAssignableFrom(allClasses[i]) && allClasses[i].IsClass && !allClasses[i].IsAbstract)
            {
                output.Add(allClasses[i]);
            }
        }
        return output;
    }
}
#endif
