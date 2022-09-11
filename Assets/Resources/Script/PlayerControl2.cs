using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    [SerializeField]
    private GameObject hand = null;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    [Range(0,10)]
    private float enemy_moveSpeed = 0;

    Animation spartanKing;
    Rigidbody rigidbody;

    CharacterController pcControl;
    public float runSpeed = 6.0f;
    Vector3 velocity;

    public float ratationSpeed = 360.0f;

    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("metarig|Idle");
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        hand.transform.gameObject.SetActive(false);
        enemy_moveSpeed = 0;
        pcControl = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Animation_Play_3();
    }

    void Animation_Play_3()
    {
        //플레이어 따라가기
        Vector3 playerToMe;
        playerToMe.x = player.transform.position.x - transform.position.x;
        playerToMe.y = player.transform.position.y - transform.position.y;
        playerToMe.z = player.transform.position.z - transform.position.z;

        double distance = Mathf.Sqrt(Mathf.Pow(playerToMe.x, 2) + Mathf.Pow(playerToMe.y, 2) + Mathf.Pow(playerToMe.z, 2));

        //거리 3보다 작아지면 안가게 하기 추가하기
        if(distance < 10)
        {
            enemy_moveSpeed = 0.5f;
            transform.Translate(playerToMe * Time.deltaTime * enemy_moveSpeed, Space.World);

            transform.forward = playerToMe;
            StartCoroutine("AttackToIdle");

            if (distance < 5)
            {
                hand.SetActive(true);
                spartanKing.wrapMode = WrapMode.Once;
                spartanKing.CrossFade("metarig|Attack_1", 0.1f);
            }
        }
        else
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("metarig|Idle", 0.1f);
        }
    }

    IEnumerator AttackToIdle()
    {
        if (spartanKing.IsPlaying("metarig|Attack_1") != true) // isPlaying은 현상태
        {
            float delayTime;
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("metarig|Run", 0.1f);
            delayTime = spartanKing.GetClip("metarig|Run").length - 0.1f; //1.167f - 0.7f; 
            yield return new WaitForSeconds(delayTime);
            hand.SetActive(false);
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("metarig|Run", 0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.gameObject != hand)
        {
            print("enemy die");
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("metarig|Death");
        }
    }
}
