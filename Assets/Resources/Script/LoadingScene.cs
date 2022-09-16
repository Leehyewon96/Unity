using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    AsyncOperation async;

    float delayTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingNextScene(GameManager.Instance.NextSceneName));
    }

    // Update is called once per frame
    void Update()
    {
        DelayTime();
    }

    void DelayTime()
    {
        delayTime += Time.deltaTime;
    }

    IEnumerator LoadingNextScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            yield return true;
        }

        while(async.progress >= 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            if(delayTime > 2.0f)
                break;
        }
        async.allowSceneActivation = true;
    }
}
