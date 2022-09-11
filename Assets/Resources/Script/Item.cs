using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    [Range(0, 500)]
    private float itemSpeed = 10.0f;

    Rigidbody2D rigidbody;

    private float timer = 0.0f;
    private float waiting = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waiting)
        {
            Destroy(this.gameObject);
        }

        MoveItem();
    }

    void MoveItem()
    {
        if (GameManager.Instance.gameState == 1)
        {
            transform.Translate(Vector2.right * -itemSpeed * Time.deltaTime);
        }
        else if(GameManager.Instance.gameState == 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if(hitObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.cash += 5;
            Destroy(this.gameObject);
        }
    }

}
