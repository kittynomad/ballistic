using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AbstractSerializer))]
public class AbstractSerializerDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return base.GetPropertyHeight(property, label);
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
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
