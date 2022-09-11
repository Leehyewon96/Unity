using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_GameOver : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject cashText;

    public GameObject defaultUI;
    public GameObject OptionUI;


    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.gameState == 3)
        {
            scoreText.GetComponent<Text>().text = GameManager.Instance.gameScore.ToString();
            cashText.GetComponent<Text>().text = GameManager.Instance.cash.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RestartBtn()
    {
        GameManager.Instance.gameState = 0;
        GameManager.Instance.gameScore = 0;
        GameManager.Instance.attackGuage = 0;
        GameManager.Instance.cash = 0;
        GameManager.Instance.userID = "";
        

        this.gameObject.SetActive(false);
        //defaultUI.SetActive(true);
        OptionUI.SetActive(true);
    }
}
