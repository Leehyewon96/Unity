using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDefault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int count = 0;
    private void OnGUI()
    {
        string str = "Text Test2";
        string str2 = "ddd";
        string str3 = "Click Count : " + count.ToString();
        int i; // Ŭ����

        GUI.TextArea(new Rect(200, 50, 100, 30), "Text Test");
        GUI.TextField(new Rect(200, 100, 100, 30), str3);
        //GUI.Box(new Rect(200, 150, 150, 30), str3); // ��� ����

        if(GUI.Button(new Rect(200, 150, 150, 30), "Ŭ��"))
        {
            count++;
        }
    }
}
