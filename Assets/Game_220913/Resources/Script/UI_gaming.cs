using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gaming : MonoBehaviour
{
    public GameObject GameOverUI = null;

    public Text cash = null;

    public GameObject ID = null;
    
    public Image stageGauge = null;
    public GameObject[] health;

    // Start is called before the first frame update
    void Start()
    {
        ID.GetComponent<Text>().text = GameManager.Instance.userID;
        print(GameManager.Instance.userID);
    }

    // Update is called once per frame
    void Update()
    {
        ID.GetComponent<Text>().text = GameManager.Instance.userID;

        cash.text = GameManager.Instance.cash.ToString() + "X";

        stageGauge.fillAmount = GameManager.Instance.StageGuage / 100.0f;

        if (GameManager.Instance.life_num < health.Length)
        {
            health[GameManager.Instance.life_num].SetActive(false);
        }

        int onCnt = 0;
        for(int i = 0; i < health.Length; i++)
        {
            if(health[i].active == true)
            {
                onCnt++;
            }
        }

        if (GameManager.Instance.life_num > onCnt)
        {
            health[onCnt].SetActive(true);
        }
        onCnt = 0;

        //게임오버
        if (GameManager.Instance.life_num == 0)
        {
            GameManager.Instance.gameState = 2;
            this.gameObject.SetActive(false);
            GameOverUI.SetActive(true);
        }
    }
}
