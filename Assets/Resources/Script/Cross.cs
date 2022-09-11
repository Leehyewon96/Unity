using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public GameObject enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float asinRes = Mathf.Asin(Vector3.Cross(transform.forward.normalized, (enemy.transform.position - transform.position).normalized).magnitude);
        asinRes = asinRes * Mathf.Rad2Deg;
        Debug.Log(asinRes);


        if (asinRes > 90.0f && asinRes < 270.0f)
            Debug.Log("뒤에 있습니다.");
        else
            Debug.Log("앞에 있습니다.");
    }
}
