using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController pcController;

    public GameObject rHand = null;
    public GameObject rFoot = null;

    public GameObject arrow = null;
    public GameObject destination = null;

    RaycastHit rayHit;
    Ray ray;
    float ray_distance= 1.0f;

    Rigidbody rigidbody;

    Animator animator;

    [SerializeField]
    [Range(0, 50)]
    public float moveSpeed = 10.0f;

    [SerializeField]
    [Range(0, 360)]
    public float rotateSpeed = 50.0f;

    [SerializeField]
    [Range(0, 360)]
    public float rotSpeed = 360.0f;

    
   

    // Start is called before the first frame update
    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        rHand.GetComponent<BoxCollider>().enabled = false;
        rFoot.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        //move();
        //pointer();
        CharacterControl();
        animatorControl();

    }

    private void animatorControl()
    {
        animator.SetFloat("Speed", pcController.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("punch");
            rHand.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(rHandColliderFalse());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("kick");
            rFoot.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(rHandColliderFalse());
        }
    }

    IEnumerator rHandColliderFalse()
    {
        yield return new WaitForSeconds(2.0f);
        rHand.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator rFootColliderFalse()
    {
        yield return new WaitForSeconds(2.0f);
        rFoot.GetComponent<BoxCollider>().enabled = false;
    }

    private bool iswall()
    {
        if (Physics.Raycast(ray, out rayHit, ray_distance))
            return true;
        else
            return false;
    }    

    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rigidbody.MovePosition(rigidbody.position + Vector3.forward * moveSpeed);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            animator.SetBool("run", true);
            if(iswall())
            {
                transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            //rigidbody.MovePosition(rigidbody.position + Vector3.forward * -moveSpeed);
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            animator.SetBool("run", true);
            if (iswall())
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rigidbody.MovePosition(rigidbody.position + Vector3.left * moveSpeed);
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime, Space.World);
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rigidbody.MovePosition(rigidbody.position + Vector3.right * moveSpeed);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
            animator.SetBool("run", true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("punch");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("kick");
        }

        if (!Input.anyKey)
        {
            animator.SetBool("run", false);
        }
    }

    private void CharacterControl()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        if(velocity.sqrMagnitude > 0.01)
        {
            Vector3 forward = Vector3.Slerp(transform.forward,
                velocity,
                rotSpeed * Time.deltaTime / Vector3.Angle(transform.forward, velocity));

            transform.LookAt(transform.position + forward);
        }

        pcController.Move(moveSpeed * Time.deltaTime * velocity + Physics.gravity * 0.1f);
    }

    private void pointer()
    {
        Vector3 desPos = new Vector3(destination.transform.position.x, transform.position.y + 2, destination.transform.position.z);
        Vector3 desToMe = desPos - transform.position;
        Vector3 arrowPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        arrow.transform.LookAt(desPos);
        //Debug.Log(new Vector3(desToMe.x, arrow.transform.position.y, desToMe.z));
        arrow.transform.position = arrowPos;
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if (hitObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            animator.SetTrigger("death");
            GameManager.Instance.life_num--;
        }

        if (hitObject.layer == LayerMask.NameToLayer("Key"))
        {
            GameManager.Instance.Key = true;
            Destroy(hitObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Coin"))
        {
            GameManager.Instance.cash += 5;
            Destroy(hitObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Present"))
        {
            GameManager.Instance.StageGuage += 10;
            Destroy(hitObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Heart"))
        {
            if(GameManager.Instance.life_num < 4)
                GameManager.Instance.life_num++;

            Destroy(hitObject);
        }

        if (hitObject.layer == LayerMask.NameToLayer("Fire"))
        {
            Debug.Log("hit Fire!");
            if(GameManager.Instance.fire)
            {
                animator.SetTrigger("hit");
                GameManager.Instance.life_num--;
            }
        }
    }
}