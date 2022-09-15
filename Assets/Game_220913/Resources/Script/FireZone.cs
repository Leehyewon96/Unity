using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    public GameObject fireZone = null;

    private float timer = 0;
    private float waiting = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waiting)
        {
            timer = 0;
            GameManager.Instance.fire = true;
            fireZone.SetActive(true);
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.fire = false;
        fireZone.SetActive(false);
    }
}
