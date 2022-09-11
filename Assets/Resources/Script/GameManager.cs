using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << : 


public class GameManager : MonoBehaviour
{
    //�̱��� ���� �ڵ� (�����ؼ� ����)
    private static GameManager sInstance;
    public static GameManager Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //���� ������Ʈ ���� ���ϰ� ��
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //����
    public int gameScore = 0;
    public string userID = "";
    public double lifeGuage = 100;
    public double attackGuage = 0;
    public int gameState = 0; // ���� �ε� 0, ������ 1, �Ͻ����� 2, ���ӿ��� 3
    public int cash = 0;

    public float BGM_Volume = 1.0f;
    public float UI_Volume = 1.0f;

    public int life_num = 3;

    public int column_num = 0;
}
