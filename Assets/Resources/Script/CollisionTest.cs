using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    float speedMove = 10.0f;
    float speedRotate = 100.0f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime;
        move = move * speedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rotate);
        transform.Translate(Vector3.forward * move);

    }

    private void OnCollisionEnter(Collision collision)//접촉시작 순간
    {
        GameObject hitObject = collision.gameObject;

        print("충돌시작: " + hitObject.name);
    }

    private void OnCollisionStay(Collision collision)//접촉되어있는중
    {
        GameObject hitObject = collision.gameObject;

        print("충돌중: " + hitObject.name);
    }

    private void OnCollisionExit(Collision collision)//접촉끝나는 순간
    {
        GameObject hitObject = collision.gameObject;

        print("충돌끝: " + hitObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        print("트리거 시작: " + hitObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;

        print("트리거 중: " + hitObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;

        print("트리거 끝: " + hitObject.name);
    }
}
