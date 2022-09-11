using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour //기둥생성함
{
    public GameObject obstacleObj_up = null;
    GameObject obj_up = null;

    [SerializeField]
    [Range(0, 10)]
    private float MoveSpeed = 10.0f;

    [SerializeField]
    [Range(0, 5)]
    private float interval = 3.0f;

    // Start is called before the first frame update
    /* IEnumerator Start() //IEnumerator->일정시간단위로 알아서 호출(코루틴 비슷)
     {
         while(true)
         {
             GameObject obj = null;
             if(obstacleObj != null)
             {
                 //transform.position;
                 obj = Instantiate(obstacleObj, transform.position, transform.rotation); // obj을 만들고 위치와 회전값을 지정함
             }
             Destroy(obj, 1.0f); //1초후에 삭제
             yield return new WaitForSeconds(1.5f); //1.5초동안 다른건 작동하고 이것만 멈췄다가 다시함(Thread 비슷)
         }
     }*/

    private void Start() //IEnumerator->일정시간단위로 알아서 호출(코루틴 비슷)
    {
        //Invoke("MakeObj", 1.0f);
        InvokeRepeating("MakeObj", 1.0f, 2.0f); //InvokeRepeating(함수, 몇초후 시작, 몇초마다반복)

        /*IEnumerator = CountTime(1.0f);
        StartCoroutine(enumerator);*/

        //StartCoroutine("CountTime", 1);
    }

    void MakeObj()
    {
        //
     
        Vector3 obj_up_location = transform.position;
        obj_up_location.y = Random.Range(-interval, interval);
        obj_up = Instantiate(obstacleObj_up, obj_up_location, transform.rotation); // obj_up을 만들고 위치와 회전값을 지정함
        //

        //MoveObj(obj_up, obj_down);
        //obj_up.transform.Translate(Vector3.right * MoveSpeed, Space.World);
        //obj_down.transform.Translate(Vector3.right * MoveSpeed, Space.World);

        //Invoke("MakeObj", 0.1f);
    }
}
