using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_End : MonoBehaviour
{
    public GameObject default_UI = null;
    public GameObject Longin_UI = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        GameManager.Instance.userID = "";
        GameManager.Instance.StageGuage = 0;
        GameManager.Instance.life_num = 4;
        GameManager.Instance.cash = 0;
        GameManager.Instance.gameState = 0;

        this.gameObject.SetActive(false);
        default_UI.SetActive(false);
        Longin_UI.SetActive(true);
    }
}
