using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    

    public GameObject Item_coin = null;
    GameObject newItem = null;

    Rigidbody2D rigidbody;

    [SerializeField]
    [Range(0, 500)]
    private float moveSpeed = 50.0f;

    float timer = 0.0f;
    float waiting = 50.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == 1) //°ÔÀÓÁß
        {
            timer += Time.deltaTime;
            if (timer > waiting)
            {
                Destroy(this.gameObject);
            }

            wolfMove();
        }
        else if(GameManager.Instance.gameState == 3)
        {
            Destroy(this.gameObject);
        }
    }

    

    void wolfMove()
    {
        transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.attackGuage += 5;
        }

        if (hitObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            newItem = Instantiate(Item_coin);
            newItem.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit Wolf");

        GameObject hitObject = collision.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.attackGuage += 20;
            Destroy(this.gameObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            
            newItem = Instantiate(Item_coin);
            newItem.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
