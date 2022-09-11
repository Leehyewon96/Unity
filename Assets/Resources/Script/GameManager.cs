using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // << : 


public class GameManager : MonoBehaviour
{
    //싱글톤 생성 코드 (복붙해서 쓰기)
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
        DontDestroyOnLoad(this.gameObject); //현재 오브젝트 삭제 못하게 함
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //공통
    public int gameScore = 0;
    public string userID = "";
    public double lifeGuage = 100;
    public double attackGuage = 0;
    public int gameState = 0; // 게임 로딩 0, 게임중 1, 일시정지 2, 게임오버 3
    public int cash = 0;

    public float BGM_Volume = 1.0f;
    public float UI_Volume = 1.0f;

    public int life_num = 3;

    public int column_num = 0;
}
