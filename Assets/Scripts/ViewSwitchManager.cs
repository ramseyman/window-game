using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject on;

    [SerializeField]
    private GameObject off;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Viewed(){
        active = true;
        on.SetActive(true);
        off.SetActive(false);
    }

    public void Unviewed(){
        active = false;
        off.SetActive(true);
        on.SetActive(false);
    }
}
