using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private Vector3 originPosition;
    private Vector3 dir;
    private bool move = false;

    [SerializeField]
    [Range(0, 50)]
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, -transform.localScale.z / 2.0f);
        
    }
    private void Awake()
    {
        dir = new Vector3(transform.forward.x, 0, transform.forward.z);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, -transform.localScale.z / 2.0f);
        transform.Translate(-dir * speed * Time.deltaTime, Space.World);
        transform.Rotate(-Vector3.right * 60.0f * Time.deltaTime, Space.Self);
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
