using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class present : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if(hitObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.item_num++;
        }

        if (hitObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameManager.Instance.item_num_enemy++;
        }
        Destroy(this.gameObject);
    }
}
