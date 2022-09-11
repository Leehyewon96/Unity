using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_column : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        if(hitObject.name == "Bip01 R Hand")
        {
            GameManager.Instance.column_num--;
            Destroy(this.gameObject);
        }
    }
}
