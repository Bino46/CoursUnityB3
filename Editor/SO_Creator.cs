using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SO_Creator : EditorWindow
{
    string className;
    string menuName;

    [MenuItem("Tools/Scriptable Object Creator")]
    public static void Open()
    {
        EditorWindow.GetWindow<SO_Creator>("Scriptable Object Creator");
    }

    private void OnEnable()
    {
        className = "";
        menuName = "";
    }

    private void OnGUI()
    {
        className = EditorGUILayout.TextField("Class Name", className);
        menuName = EditorGUILayout.TextField("Menu Name", menuName);

        className = className.Replace(' ', '_');
        menuName = menuName.Replace(' ', '/');

        if (GUILayout.Button("Create"))
        {
            CreateFile();
        }
    }

    void CreateFile()
    {
        string filename = Application.dataPath + "/" + className + ".cs";
        string content = @"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ""$CLASS"", menuName = ""$MENU"" )]
public class $CLASS : ScriptableObject
    {

    }";

        content = content.Replace("$CLASS", className).Replace("$MENU", menuName);

        File.WriteAllText(filename, content);
    }
}

