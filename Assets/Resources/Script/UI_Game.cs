using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << : 

public class UI_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnGUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(400, 250, 150, 30), "게임씬 확인"))
        {
            GameManager.Instance.ChangeScene("99 End"); //매니저이용해서 씬전환
           // SceneManager.LoadScene("99 End"); //전환할 씬 이름 복붙
        }
    }

}
