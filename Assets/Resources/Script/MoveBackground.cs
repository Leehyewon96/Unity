using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public GameObject target = null;
    public GameObject target2 = null;

    float MoveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
        target2.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
        Vector3 origin_locate;
        origin_locate.x = 40.0f;
        origin_locate.y = 1.0f;
        origin_locate.z = 0.0f;

        if (target.transform.position.x < -40.0f)
            target.transform.position = origin_locate;

        if (target2.transform.position.x < -40.0f)
            target2.transform.position = origin_locate;
    }
}
