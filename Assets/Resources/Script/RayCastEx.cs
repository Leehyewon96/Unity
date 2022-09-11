using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 5.0f;
    private RaycastHit rayHit;
    private RaycastHit[] rayHits;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        //ray = new Ray(transform.position, transform.forward);//위 세줄과 같음
    }

    // Update is called once per frame
    void Update()
    {
        Ray_1();
        Ray_2();
        //Ray_3();
        OnDrawGizmos();
    }

    void Ray_1()
    {
        if(Physics.Raycast(ray, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name + " " + rayHit.distance.ToString());
        }
    }

    void Ray_2()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for(int index = 0; index<rayHits.Length; index++)
        {
            Debug.Log(rayHits[index].collider.gameObject.name + "hit!!");
        }

        string objName = "";
        rayHits = Physics.SphereCastAll(ray, 2.0f, distance);
        foreach(RaycastHit hit in rayHits)
        {
            objName += hit.collider.name + " , ";
        }
        print(objName);
    }

    void Ray_3()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            if(rayHits[index].collider.gameObject.tag == "Obstacle")
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! -- Tag");

            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Second Layer"))
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! -- Layer");
        }
    }

    private void OnDrawGizmos()
    {
        OnDrawGizmos_2();
    }

    private void OnDrawGizmos_2()
    {
        if(rayHits != null)
        {
            for (int index = 0; index < rayHits.Length; index++)
            {
                if(rayHits[index].collider != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(rayHits[index].point, 0.1f);

                    //:to point
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayHits[index].distance);

                    //: normal
                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(rayHits[index].point, rayHits[index].point + rayHits[index].normal);

                    //: reflect
                    Gizmos.color = Color.magenta;
                    Vector3 reflect = Vector3.Reflect(transform.forward, rayHits[index].normal);
                    Gizmos.DrawLine(rayHits[index].point, rayHits[index].point + reflect);
                    
                }
            }
        }
    }

    private void OnDrawGizmos_1()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        Gizmos.color = new Color32(255, 0, 0, 255);
        Gizmos.DrawSphere(ray.origin, 0.1f);

        //Gizmos.color = new Color32(255, 255, 0, 255);
        Gizmos.DrawWireSphere(ray.origin, distance);
    }
}
