using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Pause : MonoBehaviour
{
    
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClips;

    [SerializeField]
    [Range(0, 500)]
    private float cloudSpeed = 100.0f;

    public GameObject continue_BTN = null;

    public GameObject bgmVolume_slider = null;
    public GameObject UI_Volume_slider = null;

    //public Slider bgmVolume_slider = null;
    //public Slider UI_Volume_slider = null;

    public GameObject defaultUI = null;

    public GameObject leftTop_cloud = null;
    public GameObject leftBottom_cloud = null;
    public GameObject rightTop_cloud = null;
    public GameObject rightBottom_cloud = null;

    int restart = 0;

    // Start is called before the first frame update
    void Start()
    {
        leftTop_cloud.transform.position = new Vector3(-400, 300, 0);
        leftBottom_cloud.transform.position = new Vector3(-400, 50, 0);
        rightTop_cloud.transform.position = new Vector3(1200, 300, 0);
        rightBottom_cloud.transform.position = new Vector3(1200, 50, 0);

        audioSource = gameObject.GetComponent<AudioSource>();

        bgmVolume_slider.GetComponent<Slider>().value = 0.5f;
        UI_Volume_slider.GetComponent<Slider>().value = 0.5f;
        //bgmVolume_slider.value = 0.5f;
        //UI_Volume_slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ShowVolumeBar();

        if (restart == 0)
        {
            if (leftTop_cloud.transform.position.x < 200)
            {
                leftTop_cloud.transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
            }
            else
            {
                continue_BTN.SetActive(true);
                bgmVolume_slider.SetActive(true);
                UI_Volume_slider.SetActive(true);
            }

            if (leftBottom_cloud.transform.position.x < 200)
            {
                leftBottom_cloud.transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
            }

            if (rightTop_cloud.transform.position.x > 600)
            {
                rightTop_cloud.transform.Translate(Vector2.right * -cloudSpeed * Time.deltaTime);
            }

            if (rightBottom_cloud.transform.position.x > 600)
            {
                rightBottom_cloud.transform.Translate(Vector2.right * -cloudSpeed * Time.deltaTime);
            }
        }
           

        //다시시작할때
        if (restart == 1)
        {
            continue_BTN.SetActive(false);
            bgmVolume_slider.SetActive(false);
            UI_Volume_slider.SetActive(false);

            if (leftTop_cloud.transform.position.x > -400)
            {
                leftTop_cloud.transform.Translate(Vector2.right * -cloudSpeed * Time.deltaTime);
            }
            else
            {
                GameManager.Instance.gameState = 1;
                restart = 0;
                this.gameObject.SetActive(false);
                defaultUI.SetActive(true);
            }

            if (leftBottom_cloud.transform.position.x > -400)
            {
                leftBottom_cloud.transform.Translate(Vector2.right * -cloudSpeed * Time.deltaTime);
            }

            if (rightTop_cloud.transform.position.x < 1200)
            {
                rightTop_cloud.transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
            }

            if (rightBottom_cloud.transform.position.x < 1200)
            {
                rightBottom_cloud.transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
            }
        }
    }

    float pre_volume = GameManager.Instance.UI_Volume;
    public void ShowVolumeBar()
    {
        GameManager.Instance.BGM_Volume = bgmVolume_slider.GetComponent<Slider>().value / bgmVolume_slider.GetComponent<Slider>().maxValue;
        GameManager.Instance.UI_Volume = UI_Volume_slider.GetComponent<Slider>().value / UI_Volume_slider.GetComponent<Slider>().maxValue;

        if(pre_volume != GameManager.Instance.UI_Volume)
        {
            playVolume_UI(audioClips[0]);
        }
        pre_volume = GameManager.Instance.UI_Volume;
    }

    void playVolume_UI(AudioClip clip)
    {
        if (audioSource.isPlaying)
            return;

        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    void RestartBtn_()
    {
        restart = 1;

        /*GameManager.Instance.gameState = 1;
        this.gameObject.SetActive(false);
        defaultUI.SetActive(true);*/
    }
}
