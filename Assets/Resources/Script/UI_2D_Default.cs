using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Default : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    public GameObject textObj = null;
    public GameObject scoreObj = null;
    public GameObject cashObj = null;
    public Image imgHPbar;

    public GameObject gameOverUI = null;
    public GameObject PauseUI = null;

    // Start is called before the first frame update
    void Start()
    {
        textObj.GetComponent<Text>().text = GameManager.Instance.userID.ToString();
        scoreObj.GetComponent<Text>().text = "Score : " + GameManager.Instance.gameScore.ToString();
        cashObj.GetComponent<Text>().text = GameManager.Instance.cash.ToString();
        ShowHPBar((int)GameManager.Instance.lifeGuage);

        audioSource = gameObject.GetComponent<AudioSource>();
        PlaySound(audioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameManager.Instance.BGM_Volume;

        textObj.GetComponent<Text>().text = GameManager.Instance.userID.ToString();
        scoreObj.GetComponent<Text>().text = "Score : " + GameManager.Instance.gameScore.ToString();
        cashObj.GetComponent<Text>().text = GameManager.Instance.cash.ToString();
        ShowHPBar((int)GameManager.Instance.lifeGuage - (int)GameManager.Instance.attackGuage);

        if(GameManager.Instance.lifeGuage - GameManager.Instance.attackGuage == 0)
        {
            GameManager.Instance.gameState = 3; //게임오버 상태 전환
            this.gameObject.SetActive(false);
            gameOverUI.SetActive(true);
        }

        if (GameManager.Instance.gameState == 1 && (Input.GetKey(KeyCode.Escape)))
        {
            GameManager.Instance.gameState = 2; //일시정지 상태 전환
            PauseUI.SetActive(true);
        }


    }
    public void ShowHPBar(int hp)
    {
        imgHPbar.fillAmount = (float)hp / (float)GameManager.Instance.lifeGuage;
    }

    void PlaySound(AudioClip clip)
    {
        StopSound();
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.Play();
    }

    void StopSound()
    {
        audioSource.Stop();
    }
}
