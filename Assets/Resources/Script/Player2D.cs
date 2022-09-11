using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClip;

    private AudioSource audioSource;

    private Rigidbody2D rigidBody;

    [SerializeField]
    [Range(0,500)]
    public float maxSpeed = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move_2D();

        if(GameManager.Instance.gameState == 3)
        {
            transform.position = new Vector3(-260, 7, 0);
        }
    }

    void Move_2D()
    {
        if(GameManager.Instance.gameState == 1)
        {
            audioSource.volume = GameManager.Instance.UI_Volume;

            if (Input.GetKey(KeyCode.W))
            {
                PlaySound_Loop(audioClip[0]);
                transform.Translate(Vector2.up * maxSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                PlaySound_Loop(audioClip[0]);
                transform.Translate(Vector2.up * -maxSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                PlaySound_Loop(audioClip[0]);
                transform.Translate(Vector2.right * -maxSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                PlaySound_Loop(audioClip[0]);
                transform.Translate(Vector2.right * maxSpeed * Time.deltaTime);
            }
        }
    }

    void PlaySound_Loop(AudioClip clip)
    {
        if (audioSource.isPlaying)
            return;

        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    void StopAndPlay(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if(hitObject.layer == LayerMask.NameToLayer("Wolf"))
        {
            StopAndPlay(audioClip[1]);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Item"))
        {
            StopAndPlay(audioClip[2]);
        }
    }
}
