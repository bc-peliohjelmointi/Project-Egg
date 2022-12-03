using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateFolders : EditorWindow
{
    private static string projectName = "";

    [MenuItem("Tools/Create Default Folders")]
    private static void SetUpFolders()
    {
        CreateFolders window = ScriptableObject.CreateInstance<CreateFolders>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 150);
        window.ShowPopup();
    }

    private static void CreateAllFolders()
    {
        List<string> folders = new List<string>
        {
            "Art",
            "Art/Animations",
            "Art/Animations/Controllers",
            "Art/Materials",
            "Art/Models",
            "Art/Textures",
            "Art/Particles",
            "Art/UI",
            "Art/UI/Fonts",
            "Audio",
            "Audio/Music",
            "Audio/SFX",
            "Code",
            "Code/Scripts",
            "Code/Shaders",
            "Editor",
            "Level",
            "Level/Scenes",
            "Level/Scenes/Levels",
            "Level/Scenes/Menu",
            "Level/Scenes/Loading",
            "Level/Scenes/Other",
            "Level/Scenes/Other/Debug",
            "Level/Scenes/Other/Testing",
            "Level/Scenes/Other/Temp",
            "Level/Scenes/Other/Unused",
            "Level/Prefabs",
            "Level/LightSettings",
            "Settings",
            "Settings/PlayerSettings",
            "Settings/QualitySettings",
            "ThirdParty"
        };

        foreach (string folder in folders)
        {
            if (!Directory.Exists($"Assets/{projectName}/{folder}"))
            {
                Directory.CreateDirectory($"Assets/{projectName}/{folder}");
                
            }
        }

        AssetDatabase.Refresh();
    }

    void OnGUI()
    {
        GUILayout.Label("Create Default Folders", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Insert the Project name used as the root folder");
        projectName = EditorGUILayout.TextField("Project Name: ",projectName);
        Repaint();
        GUILayout.Space(10);
        if (GUILayout.Button("Create Folders"))
        {
            CreateAllFolders();
            Debug.Log("Teki");
            Close();
        }
        
    }
}
