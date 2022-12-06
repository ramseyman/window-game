using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSwitchManager : MonoBehaviour
{
    public bool active = false;

    [SerializeField]
    private GameObject on;

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
        on.SetActive(false);
    }

    public void Unviewed()
    {
        active = true;
        on.SetActive(true);
    }
}
