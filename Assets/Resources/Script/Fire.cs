using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioClip[] AudioClips;
    private AudioSource audioSource;

    private float timer = 0.0f;
    private float waiting = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = GameManager.Instance.UI_Volume;
        playSound(AudioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameManager.Instance.UI_Volume;

        timer += Time.deltaTime;
        if(timer > waiting)
        {
            Destroy(this.gameObject);
        }
    }

    void playSound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
