using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    [SerializeField]
    GameObject hand = null;

    [SerializeField]
    [Range(0,15)]
    float moveSpeed = 0;

    [SerializeField]
    [Range(0, 50)]
    float rotSpeed = 50.0f;

    Animation spartanKing;
    Rigidbody rigidbody;

    CharacterController pcControl;
    public float runSpeed = 6.0f;
    Vector3 velocity;

    bool game = true;

    public float ratationSpeed = 360.0f;

    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.Play("idle");
        rigidbody = this.gameObject.GetComponent<Rigidbody>();

        pcControl = gameObject.GetComponent<CharacterController>();
        hand.transform.gameObject.SetActive(false);
        moveSpeed = 0;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(game == true)
        {
            if (GameManager.Instance.column_num == 5)
            {
                GameManager.Instance.ChangeScene("Spartan_GameEnd");
                game = false;
            }
        }*/
        
        //Animation_Play_1();
        //Animation_Play_2();
        Animation_Play_3();
        //CharacterControl_Slerp();
    }

    void StopSound()
    {
        audioSource.Stop();
    }

    void PlayAndStop(AudioClip clip)
    {
        StopSound();
        audioSource.clip = clip;
        audioSource.Play();
    }

    void PlaySound_Loop(AudioClip clip)
    {
        if (audioSource.isPlaying) return;

        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    void Animation_Play_1() //한번씩만 테스트
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.Play("attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.Play("idle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.Play("walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.Play("run");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spartanKing.Play("charge");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spartanKing.Play("idlebattle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spartanKing.Play("resist");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spartanKing.Play("victory");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spartanKing.Play("salute");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spartanKing.Play("die");
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            spartanKing.Play("diehard");
        }
    }

    void Animation_Play_2()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
           // spartanKing.Play("attack");
        }

       /* if (Input.GetKeyDown(KeyCode.G))
        {
            spartanKing.wrapMode = WrapMode.Once;
            //spartanKing.CrossFade("attack", 0.3f);
            spartanKing.Play("attack");
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("run");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("charge");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idlebattle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("resist");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("victory");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("salute");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("die");
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("diehard");
        }
    }

    void Animation_Play_3()
    {
        if (spartanKing.IsPlaying("attack") != true)
        {
            if (moveSpeed == 0)
            {
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade("idle", 0.3f);
            }
            else
            {
                PlaySound_Loop(audioClips[0]);
                spartanKing.wrapMode = WrapMode.Loop;
                spartanKing.CrossFade("run", 0.3f);
            }
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            //PlaySound_Loop(audioClips[0]);

            moveSpeed = 10.0f;
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -rotSpeed * Time.deltaTime, Space.World);
            }

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //PlaySound_Loop(audioClips[0]);

            moveSpeed = 10.0f;
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * -rotSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.World);
            }

            transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //PlaySound_Loop(audioClips[0]);

            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
           //PlaySound_Loop(audioClips[0]);

            transform.Rotate(Vector3.up * -rotSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hand.transform.gameObject.SetActive(true);
            transform.gameObject.SetActive(true);
            StartCoroutine("AttackToIdle");
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            moveSpeed = 0;
        }


    }

    IEnumerator AttackToIdle()
    {
        if(spartanKing.IsPlaying("attack") != true) // isPlaying은 현상태
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
            float delayTime = spartanKing.GetClip("attack").length - 0.3f; //1.167f - 0.7f; 

            yield return new WaitForSeconds(delayTime);

            hand.transform.gameObject.SetActive(false);
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.3f);
        }
    }

    private void CharacterControl()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        velocity *= runSpeed;

        if(velocity.magnitude > 0.5f)
        {
            spartanKing.CrossFade("run", 0.3f);
            transform.LookAt(transform.position + velocity);
        }
        else
        {
            spartanKing.CrossFade("idle", 0.3f);

        }
        //pcControl.Move(velocity * Time.deltaTime + Physics.gravity * 0.1f);
        pcControl.SimpleMove(velocity + Physics.gravity);
    }

    private void CharacterControl_Slerp() 
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
           0,
           Input.GetAxis("Vertical"));

        //direction *= runSpeed;

        // 움직이면
        if (direction.sqrMagnitude > 0.01f)
        {
            spartanKing.CrossFade("run", 0.3f);


            //속도 방향과 플레이어 방향 맞춰서 회전 자연스럽게
            Vector3 forward = Vector3.Slerp(transform.forward,
                direction,
                ratationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );

            transform.LookAt(transform.position + forward);
            //
        }
        // 안움직이면
        else
        {          
            if(spartanKing.IsPlaying("attack") != true)
                spartanKing.CrossFade("idle", 0.3f);
        }

        pcControl.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * 0.1f);
        //pcControl.SimpleMove(direction + Physics.gravity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.gameObject != hand && hitObject.layer != LayerMask.NameToLayer("Background"))
        {
            print("player die");
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.Play("die");
        }
    }
}
