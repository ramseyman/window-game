using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchActivation : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject[] switches;

    ViewSwitchManager viewManager;
    BlindSwitchManager blindManager;

    void Start() {

    }
    // Update is called once per frame
    void Update() {

    }

    public void GameCheck() {
        for (int index = 0; index < switches.Length; index++) {
            ChangeState(switches[index]);
        }
        for (int index = 0; index < switches.Length; index++) {
            if (switches[index].tag.Equals("ViewSwitch")){
                viewManager = switches[index].GetComponent<ViewSwitchManager>();
                if (viewManager.active == false)
                    return;
            }
            if (switches[index].tag.Equals("BlindSwitch")){
                blindManager = switches[index].GetComponent<BlindSwitchManager> ();
                if (blindManager.active == false)
                    return;
            }
        }
        Proceed();
        return;
    }

    public void ChangeState(GameObject gameSwitch){
        if (gameSwitch.tag.Equals("ViewSwitch")){
            ViewSwitchManager vm = gameSwitch.GetComponent<ViewSwitchManager>();
            if (CheckBounds(gameSwitch))
                vm.Viewed();
            else
            {
                vm.Unviewed();
            }
        }
        if (gameSwitch.tag.Equals("BlindSwitch")){
            BlindSwitchManager bm = gameSwitch.GetComponent<BlindSwitchManager>();
            if (CheckBounds(gameSwitch))
                bm.Viewed();
            else if(CheckOutside(gameSwitch))
            {
                bm.Unviewed();
            }
        }
    }

    public bool CheckBounds(GameObject gameSwitch){
        SpriteRenderer render = gameSwitch.GetComponent<SpriteRenderer>();
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float camMinX = cam.transform.position.x - camWidth;
        float camMaxX = cam.transform.position.x + camWidth;

        float camMinY = cam.transform.position.y - camHeight;
        float camMaxY = cam.transform.position.y + camHeight;

        float switchMinX = render.transform.position.x - render.bounds.size.x / 2f;
        float switchMaxX = render.transform.position.x + render.bounds.size.x / 2f;

        float switchMinY = render.transform.position.y - render.bounds.size.y / 2f;
        float switchMaxY = render.transform.position.y + render.bounds.size.y / 2f;

        bool withinX = false;
        bool withinY = false;

        if (switchMinX > camMinX && switchMaxX < camMaxX)
            withinX = true;
        if (switchMinY > camMinY && switchMaxY < camMaxY)
            withinY = true;

        return (withinX && withinY);
    }

    public bool CheckOutside(GameObject gameSwitch){
        SpriteRenderer render = gameSwitch.GetComponent<SpriteRenderer>();
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float camMinX = cam.transform.position.x - camWidth;
        float camMaxX = cam.transform.position.x + camWidth;

        float camMinY = cam.transform.position.y - camHeight;
        float camMaxY = cam.transform.position.y + camHeight;

        float switchMinX = render.transform.position.x - render.bounds.size.x / 2f;
        float switchMaxX = render.transform.position.x + render.bounds.size.x / 2f;

        float switchMinY = render.transform.position.y - render.bounds.size.y / 2f;
        float switchMaxY = render.transform.position.y + render.bounds.size.y / 2f;

        bool outsideX = false;
        bool outsideY = false;

        if (switchMinX > camMaxX || switchMaxX < camMinX)
            outsideX = true;
        if (switchMinY > camMaxY || switchMaxY < camMinY)
            outsideY = true;

        return (outsideX || outsideY);
    }
    
    public void Proceed(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
