using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    Text titleText;
    public InputField inputText;

    public GameObject DefaultUI = null;

    // Start is called before the first frame update
    void Start()
    {
        titleText = gameObject.GetComponentInChildren<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClickOK()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.gameState = 1; //∞‘¿”¡ﬂ
        DefaultUI.SetActive(true);
    }

    void onTextChanged()
    {
        if (titleText != null)
        {
            if (inputText.text.Length <= 6)
            {
                titleText.text = inputText.text;
                GameManager.Instance.userID = inputText.text;
            }
        }
    }

    void onTextEditEnd()
    {
        if (titleText != null)
        {
            if (inputText.text.Length <= 6)
            {
                titleText.text = inputText.text;
                GameManager.Instance.userID = inputText.text;
            }
        }
    }
}
