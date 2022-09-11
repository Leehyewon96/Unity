using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClip;

    private AudioSource audioSource;

    public GameObject player = null;

    public GameObject bullet = null;
    GameObject newBullet = null;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameManager.Instance.UI_Volume;
        transform.position = player.transform.position;
        makeBullet();
    }

    void makeBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance.gameState == 1)
            {
                Vector2 bullet_pos = transform.position;
                bullet_pos.x = transform.position.x + 60;
                newBullet = Instantiate(bullet);
                newBullet.transform.position = bullet_pos;
                stopAndPlay(audioClip[0]);
            }
        }
    }
    void stopAndPlay(AudioClip clip)
    {
        StopSound();
        audioSource.clip = clip;
        audioSource.Play();
    }

    void StopSound()
    {
        audioSource.Stop();
    }
}
