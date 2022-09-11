using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life : MonoBehaviour
{
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = GameManager.Instance.life_num.ToString();
    }
}
