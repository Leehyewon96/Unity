using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2D_Option : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClips;

    private AudioSource audioSource;


    public GameObject DefaultUI = null;

    Text titleText;
    public InputField inputText;


    // Start is called before the first frame update
    void Start()
    {
        titleText = gameObject.GetComponentInChildren<Text>() as Text;
        audioSource = gameObject.GetComponent<AudioSource>();

        PlaySound(audioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClickOK()
    {
        this.gameObject.SetActive(false);
        DefaultUI.SetActive(true);
        GameManager.Instance.gameState = 1;
    }

    void onTextEditEnd()
    {
        if (titleText != null)
        {
            if(inputText.text.Length <= 6)
            {
                titleText.text = inputText.text;
                GameManager.Instance.userID = inputText.text;
            }
        }
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
