using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLayer : MonoBehaviour
{
    private new Renderer renderer;
    private float offset;
    private float speed;
    public void Start()
    {
        offset = 0;
        speed = 0.2f;
        renderer = GetComponent<Renderer>();
    }

    public void Update()
    {
        offset = Time.deltaTime * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
