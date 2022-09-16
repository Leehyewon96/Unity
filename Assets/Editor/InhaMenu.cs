using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class InhaMenu : MonoBehaviour
{
    [MenuItem("InhaMenu/Clear PlayerPrefs")]
    private static void Clear_PlayerPresAll()
    {
        PlayerPrefs.DeleteAll();
        print("Clear_PlayerPresAll()");
    }

    [MenuItem("InhaMenu/SubMenu/Selection")]
    private static void subMenu_Selected()
    {
        print("subMenu_Selected");
    }

    [MenuItem("InhaMenu/SubMenu/Hotkey Test 1 %#[")]
    private static void subMenu_Hotkey_()
    {
        // (% : ctrl) + (# : shift) - [
        print("Hotkey Test : Ctrl + Shift + [");
    }

    [MenuItem("Assets/Load Selected Scene %#L")]
    private static void LoadSelectedScene()
    {
        var selected = Selection.activeObject;

        if(EditorApplication.isPlaying)
        {
            EditorSceneManager.LoadScene(
            AssetDatabase.GetAssetPath(selected));
        }  
        else
        {
            EditorSceneManager.OpenScene(
            AssetDatabase.GetAssetPath(selected));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Clear_PlayerPresAll();
        subMenu_Selected();
        LoadSelectedScene();
    }
}
