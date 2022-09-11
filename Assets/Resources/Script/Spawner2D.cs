using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public GameObject wolf = null;
    GameObject newWolf = null;

    [SerializeField]
    [Range(0, 10)]
    private float interval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeWolf", 1.0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeWolf()
    {
        if(GameManager.Instance.gameState == 1)
        {
            Vector2 wolf_location = wolf.transform.position;
            wolf_location.y = Random.Range(-170, 140);
            newWolf = Instantiate(wolf);
            newWolf.transform.position = wolf_location;
        }
    }
}
