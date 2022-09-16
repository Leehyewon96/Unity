using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoNextScene()
    {
        Debug.Log("GoNextScene - Change Loading Scene");
        GameManager.Instance.NextSceneName = "Mechanim_IK";
        SceneManager.LoadScene("33 Loading");
    }
}
