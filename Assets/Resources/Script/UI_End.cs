using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << : 

public class UI_End : MonoBehaviour
{
    bool button_ = true;
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

        if (button_)
        {
            if (GUI.Button(new Rect(450, 400, 150, 30), "Restart"))
            {
                GameManager.Instance.column_num = 0;
                GameManager.Instance.ChangeScene("Animation"); //�Ŵ����̿��ؼ� ����ȯ
                                                               //SceneManager.LoadScene("03 Game"); //��ȯ�� �� �̸� ����
                button_ = false;
            }
        }
    }
}
