using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CheatWindow : EditorWindow
{
    string[] cheatList = new string[] { "치트",
            "골드생성",
            "포인트생성", };

    static int selectIndex = 0;
    int getInt = 0;
    string getString = "";

    [MenuItem("InhaMenu/SubMenu/치트 명령창1", false, 0)]

    static public void OpenCheatWindow1()
    {
        CheatWindow getWindow = EditorWindow.GetWindow<CheatWindow>(false, "Cheat window", true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OpenCheatWindow1();
    }

    private void OnGUI()
    {
        GUILayout.Space(10.0f);
        int getIndex = EditorGUILayout.Popup(selectIndex,
            cheatList, GUILayout.MaxWidth(200.0f));

        if(selectIndex != getIndex)
        {
            selectIndex = getIndex;
        }

        GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f)); // EndHorizontal 반드시 필요
        string cheatText = "";

        if(selectIndex == 0) // : cheat
        {
            GUILayout.Label("치트키 입력", GUILayout.Width(70.0f));
            getString = EditorGUILayout.TextField(getString, GUILayout.Width(100.0f));
            cheatText = string.Format("치트키 : {0}", getString);
        }
        else if(selectIndex == 1) // : gold
        {
            GUILayout.Label("골드", GUILayout.Width(70.0f));
            getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
            int.TryParse(getString, out getInt);
            cheatText = string.Format("골드 : {0}", getInt);
        }
        else if (selectIndex == 2) // : point
        {
            GUILayout.Label("포인트", GUILayout.Width(70.0f));
            getString = EditorGUILayout.TextField(getInt.ToString(), GUILayout.Width(100.0f));
            int.TryParse(getString, out getInt);
            cheatText = string.Format("포인트 : {0}", getInt);
        }

        GUILayout.EndHorizontal();



        //-----------------------------------------------------------------------------------------
        GUILayout.Space(20.0f);
        GUILayout.BeginHorizontal(GUILayout.MaxWidth(800.0f)); // EndHorizontal 반드시 필요
        {
            GUILayout.BeginVertical(GUILayout.MaxWidth(300.0f));
            {
                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f));
                {
                    if(GUILayout.Button("\n적용\n", GUILayout.Width(100.0f)))
                    {
                        getInt = 0;
                        getString = "";
                        Debug.Log(cheatText);
                    }
                }
                GUILayout.EndHorizontal();


                GUILayout.BeginHorizontal(GUILayout.MaxWidth(300.0f));
                {
                    if(GUILayout.Button("\n 백그라운드 \n 실행 \n", GUILayout.Width(100.0f)))
                    {
                        Application.runInBackground = true;
                    }
                    if (GUILayout.Button("\n 백그라운드 \n 실행 안함\n", GUILayout.Width(100.0f)))
                    {
                        Application.runInBackground = false;
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();

    }
}
