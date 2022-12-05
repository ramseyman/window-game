using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1;

    // Update is called once per frame
    void Update()
    {
        // this is currently just when a button is clicked?
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }
        // if the above is commented out, it can proceed to the next level but the start transition has disappeared for some reason and only starts on the end animation
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        // Play animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
