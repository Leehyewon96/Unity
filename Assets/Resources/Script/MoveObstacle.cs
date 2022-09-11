using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float MoveSpeed = 10.0f;

    float timer = 0.0f;
    float waiting = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waiting)
        {
            Destroy(this.gameObject);
        }
        moveObj();
    }

    void moveObj()
    {
        transform.Translate(Vector3.right * -MoveSpeed * Time.deltaTime, Space.Self);
    }
}
