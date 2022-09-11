using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour //��ջ�����
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
    /* IEnumerator Start() //IEnumerator->�����ð������� �˾Ƽ� ȣ��(�ڷ�ƾ ���)
     {
         while(true)
         {
             GameObject obj = null;
             if(obstacleObj != null)
             {
                 //transform.position;
                 obj = Instantiate(obstacleObj, transform.position, transform.rotation); // obj�� ����� ��ġ�� ȸ������ ������
             }
             Destroy(obj, 1.0f); //1���Ŀ� ����
             yield return new WaitForSeconds(1.5f); //1.5�ʵ��� �ٸ��� �۵��ϰ� �̰͸� ����ٰ� �ٽ���(Thread ���)
         }
     }*/

    private void Start() //IEnumerator->�����ð������� �˾Ƽ� ȣ��(�ڷ�ƾ ���)
    {
        //Invoke("MakeObj", 1.0f);
        InvokeRepeating("MakeObj", 1.0f, 2.0f); //InvokeRepeating(�Լ�, ������ ����, ���ʸ��ٹݺ�)

        /*IEnumerator = CountTime(1.0f);
        StartCoroutine(enumerator);*/

        //StartCoroutine("CountTime", 1);
    }

    void MakeObj()
    {
        //
     
        Vector3 obj_up_location = transform.position;
        obj_up_location.y = Random.Range(-interval, interval);
        obj_up = Instantiate(obstacleObj_up, obj_up_location, transform.rotation); // obj_up�� ����� ��ġ�� ȸ������ ������
        //

        //MoveObj(obj_up, obj_down);
        //obj_up.transform.Translate(Vector3.right * MoveSpeed, Space.World);
        //obj_down.transform.Translate(Vector3.right * MoveSpeed, Space.World);

        //Invoke("MakeObj", 0.1f);
    }
}
