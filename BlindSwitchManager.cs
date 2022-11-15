using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSwitchManager : MonoBehaviour
{
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Viewed()
    {
        active = false;
    }

    public void Unviewed()
    {
        active = true;
    }
}
