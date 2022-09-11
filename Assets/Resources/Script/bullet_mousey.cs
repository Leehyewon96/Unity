using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_mousey : MonoBehaviour
{
    [SerializeField]
    [Range(0, 50)]
    private float speed = 10.0f;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        transform.Translate(-direction.normalized * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Background"))
        {
            Destroy(this.gameObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(this.gameObject);
            Destroy(hitObject.gameObject);
        }
    }
}
