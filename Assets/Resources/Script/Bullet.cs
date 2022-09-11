using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    Rigidbody2D rigidBody2D;

    public GameObject fire = null;
    GameObject newFire = null;

    [SerializeField]
    [Range(0, 500)]
    private float bulletSpeed = 10.0f;

    private float timer = 0.0f;
    private float waiting = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == 1)
        {
            timer += Time.deltaTime;
            if (timer > waiting)
            {
                Destroy(this.gameObject);
            }

            moveBullet();
        }
        else if (GameManager.Instance.gameState == 3)
        {
            Destroy(this.gameObject);
        }


    }

    void moveBullet()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit Bullet");
        GameObject hitObject = collision.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Wolf"))
        {
            newFire = Instantiate(fire);
            newFire.transform.position = this.transform.position;
            GameManager.Instance.gameScore += 1;
            Destroy(this.gameObject);
        }
    }

   
}
