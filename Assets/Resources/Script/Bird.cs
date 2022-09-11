using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    public float jumpPower = 10.0f;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, 30.0f * jumpPower, 0)); //�ӵ��� �����ٲ��� �ʰ� ���� ����(����, ��� �ٸ��� �۵���)
        }

        if(GetComponent<Rigidbody>().velocity.y > 0)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 60.0f, Space.World);
        }
        else if (GetComponent<Rigidbody>().velocity.y < 0)
        {
            transform.Rotate(Vector3.forward * -Time.deltaTime * 60.0f, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        GameManager.Instance.life_num--;
        if (GameManager.Instance.life_num == 0)
        {
            GameManager.Instance.ChangeScene("GameOver");//���� ���� 0�̸� ���ӿ����� ��ȯ
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Mid")) //����ϸ� �������
        {
            GameManager.Instance.gameScore += 10;
        }
    }
}
