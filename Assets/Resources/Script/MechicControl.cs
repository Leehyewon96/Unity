using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechicControl : MonoBehaviour
{
    public GameObject unityChan;

    public Material material = null;

    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit[] rayHits;
    private Ray ray;

    public GameObject bullet = null;
    public GameObject newBulletPosition = null;
    public GameObject Gun = null;
    GameObject newBullet = null;
    bool space = false;

    public GameObject arrowOrigin = null;
    public GameObject newArrowPosition = null;
    GameObject newArrow = null;

    public GameObject[] Mousey;
    int idx_Mousey = 0;

    public GameObject arrow = null;
    float timer_watermelon = 0;
    float wait_watermelon = 1.0f;
    bool space_watermelon = false;
    float timer = 0;
    float timer_gun = 0;
    float waiting = 1.5f;
    float wait = 0.5f;

    public GameObject watermelon = null;


    bool shoot = false;

    [SerializeField]
    [Range(0, 50)]
    private float arrowSpeed = 10.0f;

    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;
    bool SpaceDown = false;

    // Start is called before the first frame update
    void Start()
    {
        pcController = GetComponent<CharacterController>();
        
        /*animator = GetComponent<Animator>();
        Mousey[idx_Mousey].SetActive(true);*/
    }

    private void Awake()
    {
        //arrowInitForward = arrow.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
        CharacterControl_Slerp();

        unityChan.GetComponent<Animator>().SetFloat("Speed", runSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Mousey[idx_Mousey].GetComponent<Animator>().SetBool("sit", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Mousey[idx_Mousey].GetComponent<Animator>().SetBool("sit", false);
        }

        if (idx_Mousey == 0) // Sword
        {
            Mousey[idx_Mousey].GetComponent<Animator>().SetFloat("Speed", pcController.velocity.magnitude);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Mousey[idx_Mousey].GetComponent<Animator>().SetTrigger("SwordSmash");
                //watermelon.GetComponent<CapsuleCollider>().enabled = true;
                space_watermelon = true;
            }

            if(space_watermelon)
            {
                timer_watermelon += Time.deltaTime;
                if(timer_watermelon > wait_watermelon)
                {
                    watermelon.GetComponent<CapsuleCollider>().enabled = true;
                    timer_watermelon = 0;
                    space_watermelon = false;
                }
            }
                
        }
        else if (idx_Mousey == 1) // Bow
        {
            Mousey[idx_Mousey].GetComponent<Animator>().SetFloat("Speed", pcController.velocity.magnitude);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //arrow.transform.forward = arrowInitForward;
                Mousey[idx_Mousey].GetComponent<Animator>().SetTrigger("Draw");
            }

            if(Input.GetKey(KeyCode.Space))
            {
                ray.origin = arrow.transform.position;
                ray.direction = arrow.transform.forward;
                Ray_3();

                timer += Time.deltaTime;
                
                if (timer > waiting)
                {
                    arrow.SetActive(true);
                    timer = 0;
                }
            }

            bool spaceUp = false;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Mousey[idx_Mousey].GetComponent<Animator>().SetTrigger("Throw");
                arrow.SetActive(false);
                newArrowPosition.transform.position = arrow.transform.position;
                newArrowPosition.transform.forward = arrow.transform.forward;
                newArrow = Instantiate(arrowOrigin, newArrowPosition.transform);
                if(newArrow!=null)
                {
                    Debug.Log("oK");
                }
            }
        }
        else // Gun
        {
            Mousey[idx_Mousey].GetComponent<Animator>().SetFloat("Speed", pcController.velocity.magnitude);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Mousey[idx_Mousey].GetComponent<Animator>().SetTrigger("shoot");
                space = true;
                //newBullet = Instantiate(bullet, newBulletPosition.transform);
            }
            if(space)
            {
                timer_gun += Time.deltaTime;
                if(timer_gun > wait)
                {
                    //newBulletPosition.transform.position = Gun.transform.position;
                    //newBulletPosition.transform.forward = transform.forward;
                    newBullet = Instantiate(bullet, newBulletPosition.transform);
                    if (newBullet != null)
                    {
                        Debug.Log("Bullet");
                    }
                    newBullet.transform.position = Gun.transform.position;
                    newBullet.transform.forward = -transform.forward;
                    timer_gun = 0;
                    space = false;
                }
            }
        }
    }

    void Ray_3()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            rayHits[index].collider.gameObject.GetComponentInChildren<MeshRenderer>().materials.SetValue(material, 0);

           /* if (rayHits[index].collider.gameObject.tag == "Obstacle")
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! -- Tag");

            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Second Layer"))
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! -- Layer");*/
        }
    }

    void Kick()
    {
        print("Kick");
    }

    void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            idx_Mousey++;
            if (idx_Mousey == Mousey.Length)
                idx_Mousey = 0;

            for(int i = 0; i < Mousey.Length; ++i)
            {
                if (i == idx_Mousey)
                {
                    //pcController = Mousey[i].GetComponent<CharacterController>();
                    animator = Mousey[i].GetComponent<Animator>();
                    Mousey[i].SetActive(true);
                }
                else
                {
                    Mousey[i].SetActive(false);
                }
            }
        }
    }

    void CharacterControl_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

            transform.LookAt(transform.position + forward);
        }
        else
        {

        }

        pcController.Move(direction * runSpeed * Time.deltaTime);
    }
}
