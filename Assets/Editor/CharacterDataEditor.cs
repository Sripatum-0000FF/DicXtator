using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterData))]
public class CharacterDataEditor : Editor
{
    SerializedProperty characterSprite;
    SerializedProperty firstName;
    SerializedProperty middleName;
    SerializedProperty lastName;
    SerializedProperty index;
    
    
    Texture2D previewTexture;

    int newIndex;
    private void OnEnable()
    {
        characterSprite = serializedObject.FindProperty("characterSprite");
        firstName = serializedObject.FindProperty("firstName");
        middleName = serializedObject.FindProperty("middleName");
        lastName = serializedObject.FindProperty("lastName");
        index = serializedObject.FindProperty("index");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Character Data", EditorStyles.whiteLargeLabel);
        serializedObject.Update();
        EditorGUILayout.PropertyField(characterSprite);
        
        GUILayout.Space(10);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (characterSprite.objectReferenceValue != null)
        {
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(256), GUILayout.Width(256));
            previewTexture = AssetPreview.GetAssetPreview(characterSprite.objectReferenceValue);
            EditorGUI.DrawPreviewTexture(rect, previewTexture);
            
        }
   
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(10);
        
        EditorGUILayout.LabelField($"Character Name: {firstName.stringValue} {middleName.stringValue} {lastName.stringValue}",
            EditorStyles.boldLabel);

        firstName.stringValue = EditorGUILayout.TextField("First Name", firstName.stringValue);
        middleName.stringValue = EditorGUILayout.TextField("Middle Name", middleName.stringValue);
        newIndex = EditorGUILayout.Popup("Last Name", index.intValue, FamilyData.Instance.FamilyName);

        if (GUILayout.Button("Add New Family"))
        {
            GoToPath();
        }
        
        if (newIndex != index.intValue)
        {
            index.intValue = newIndex;
        }
        lastName.stringValue = FamilyData.Instance.FamilyName[index.intValue];
        
        GUILayout.Space(2);
        DrawHorizontalLine();
        EditorGUILayout.LabelField("Role", EditorStyles.boldLabel);
        DrawPropertiesExcluding(serializedObject, "m_Script","characterSprite","firstName", "middleName", "lastName", "index");
        serializedObject.ApplyModifiedProperties();
    }

    public void DrawHorizontalLine()
    {
        Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(3), GUILayout.Width(Screen.width));
        EditorGUI.DrawRect(rect, new Color(0.16f, 0.16f, 0.16f));
    }

    public void GoToPath()
    {
        string path = AssetDatabase.GetAssetPath(FamilyData.Instance);
        UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object));

        if (obj)
        {
            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);
        }
    }
}
