using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gaming : MonoBehaviour
{
    public Text cash = null;
    public Text Id = null;
    public Image stageGauge = null;
    public GameObject[] health;

    // Start is called before the first frame update
    void Start()
    {
        Id.text = GameManager.Instance.userID;
    }

    // Update is called once per frame
    void Update()
    {
        cash.text = GameManager.Instance.cash.ToString() + "X";

        stageGauge.fillAmount = GameManager.Instance.StageGuage / 100.0f;

        if (GameManager.Instance.life_num < health.Length)
        {
            health[GameManager.Instance.life_num].SetActive(false);
        }

        if (GameManager.Instance.life_num > health.Length)
        {
            health[GameManager.Instance.life_num-1].SetActive(true);
        }
    }
}
