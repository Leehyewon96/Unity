using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << : 

public class UI_Start : MonoBehaviour
{

    bool button = true;
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
        if(button)
        {
            if (GUI.Button(new Rect(500, 500, 150, 30), "Game Start"))
            {
                GameManager.Instance.ChangeScene("Animation"); //�Ŵ����̿��ؼ� ����ȯ
                                                             //SceneManager.LoadScene("03 Game"); //��ȯ�� �� �̸� ����
                button = false;
            }
        }
    }

}
