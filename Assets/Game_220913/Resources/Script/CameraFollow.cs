using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player = null;
    Vector3 dir;

    private void Awake()
    {
        dir = player.transform.position - transform.position;

        /*dir = new Vector3(player.transform.position.x - pos.transform.position.x,
            player.transform.position.y - pos.transform.position.y,
            player.transform.position.z - pos.transform.position.z);*/

        transform.rotation = transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - dir;
    }
}
