using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float moveSpeed = 3.0f;

    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            transform.Translate(Vector3.up * -moveSpeed * Time.deltaTime);
            if (transform.position.y < -0.5f)
            {
                open = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if(hitObject.layer == LayerMask.NameToLayer("Key"))
        {
            if(GameManager.Instance.Key)
            {
                open = true;
            }
        }
    }
}
