using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resize_window : MonoBehaviour
{
    public float scale = .01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            transform.localScale = transform.localScale + new Vector3(scale, scale, 0);
        }
        if (Input.GetKey("t"))
        {
            transform.localScale = transform.localScale + new Vector3(-scale, -scale, 0);
        }
    }
}
