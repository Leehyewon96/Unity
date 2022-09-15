using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    BoxCollider collider;

    [SerializeField]
    [Range(0, 10)]
    private float moveSpeed = 3.0f;

    private float timer = 0;
    private float waiting = 4.0f;

    bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpAndDown();
    }

    void UpAndDown()
    {
        timer += Time.deltaTime;
        if(timer > waiting)
        {
            up = (!up);
            timer = 0;
        }

        if (up)
            moveUp();
        else
            moveDown();
    }

    
    void moveUp()
    {
        if(transform.position.y <= 0.25f)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            collider.isTrigger = false;
        }
    }

    void moveDown()
    {
        if (transform.position.y >= -0.2f)
        {
            transform.Translate(Vector3.up * -moveSpeed * Time.deltaTime);
            collider.isTrigger = true;
        }
    }
}
