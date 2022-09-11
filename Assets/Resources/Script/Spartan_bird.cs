using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_bird : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    private float rotSpeed = 50.0f;

    [SerializeField]
    [Range(0, 10)]
    private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void flying()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
    }
}
